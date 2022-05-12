using UnityEngine;
using System;

public class Events : MonoBehaviour
{
	public delegate void PlayerExperienceAmountChanged(float amount);
	public delegate void PlayerLevelChanged(int level);
	public delegate void KilledEnemyCounterRiseUp(int countOfKilledEnemy);
	public static event PlayerExperienceAmountChanged OnPlayerExperienceChanged;
	public static event PlayerLevelChanged OnPlayerLevelChanged;
	public static event Action PlayerDied;
	public static event Action PlayerLevelUp;
	public static event KilledEnemyCounterRiseUp CounterRisedUp;
	public static int killedEnemiesCount = 0;

    public static void OnKilledEnemyCounterRisedUp()
    {
		CounterRisedUp.Invoke(++killedEnemiesCount);
    }

	public static void PlayerLevelChange(int level)
    {
		OnPlayerLevelChanged?.Invoke(level);
    }

	public static void OnPlayerDeath()
	{
		PlayerPrefs.SetInt("Count_of_killed_enemies", killedEnemiesCount);
		PlayerDied?.Invoke();
	}

	public static void OnPlayerExperienceAmountChanged(float amount)
    {
		OnPlayerExperienceChanged?.Invoke(amount);
    }
	
	public static void OnPlayerLevelUp()
    {
		PlayerLevelUp?.Invoke();
    }
}
