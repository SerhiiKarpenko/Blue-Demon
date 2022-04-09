using UnityEngine;
public class SaveStatsForSword : MonoBehaviour
{
	public void GetSwordDamageSpeedSprite(int index)
	{
		PlayerPrefs.SetInt("Index_for_sword_stats", index);
	}

}
