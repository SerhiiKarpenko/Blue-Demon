using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof (PlayerHealth))]
[RequireComponent(typeof(PlayerLevel))]
public class PlayerUI : MonoBehaviour
{
	[SerializeField] private Slider _healthBar;
	[SerializeField] private Slider _experienceBar;
	[SerializeField] private TextMeshProUGUI _playerLevelText;
	[SerializeField] private TextMeshProUGUI _killedEnemyCounterText;

	private void Start()
	{
		SetHealthBarOnStartGame(GetComponent<PlayerHealth>().MaxHealth);
		SetExperienceBarOnStartGame();
		PlayerHealth.onChangeHp += OnPlayerHealthPointsChange;
		Events.OnPlayerExperienceChanged += ChangeExperienceSliderValue;
		Events.OnPlayerLevelChanged += UpdatePlayerLevlText;
		Events.CounterRisedUp += ChangeKilledEnemyCounterValue;
	}

    public void OnPlayerHealthPointsChange(float newHealth)
    {
		_healthBar.value = newHealth;
    }
	public void SetHealthBarOnStartGame(float maxHp)
	{
		_healthBar.maxValue = maxHp;
		_healthBar.value = _healthBar.maxValue;
	}

	public void SetExperienceBarOnStartGame()
    {
		_experienceBar.maxValue = GetComponent<PlayerLevel>().AmountToNextLevel;
		_experienceBar.value = GetComponent<PlayerLevel>().CurrentAmountOfExperience;
	}

	public void ChangeExperienceSliderValue(float newAmount)
    {
		_experienceBar.value = newAmount;
    }

	public void UpdatePlayerLevlText(int newLevel)
    {
		_playerLevelText.text = "Level:" + " " + newLevel.ToString();
    }

	public void ChangeKilledEnemyCounterValue(int countOfKilledEnemy)
    {
		_killedEnemyCounterText.text = "Enemies killed: " + countOfKilledEnemy.ToString();
    }


}
