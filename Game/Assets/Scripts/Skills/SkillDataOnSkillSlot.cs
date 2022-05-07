using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillDataOnSkillSlot : MonoBehaviour
{
	public SkillData SkillData;
	[SerializeField] private GameObject _skillsCanvas;
	[SerializeField] private GameObject _player;

	public void OnSkillSlotClick()
	{
		//add new skill to player, continue playing
		Time.timeScale = 1;
		_skillsCanvas.SetActive(false);
		SkillDataOnSkillSlot skillOnSlot = gameObject.GetComponent<SkillDataOnSkillSlot>();
		string skillName = skillOnSlot.SkillData.Name;
		Skill skillToAdd;
		switch(skillName)
		{
			case "Damage up":
				{
					skillToAdd = new DamageUpSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
				}
			case "New powers":
				{
					skillToAdd = new NewPowersSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
				}
			case "Speed up":
                {
					skillToAdd = new SpeedUpSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
                }
			case "Blood axe":
                {
					skillToAdd = new BloodAxeSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
                }
			case "Magic stone":
                {
					skillToAdd = new MagicStoneSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
                }
			case "Angel":
                {
					skillToAdd = new AngelSkill();
					AddToPlayer(_player, skillToAdd.GetType());
					break;
				}
			case "Strange book":
                {
					skillToAdd = new StrangeBookSkill();
					if(_player.TryGetComponent(out StrangeBookSkill strangeBookSkill))
                    {
						strangeBookSkill.BonusExperience += 0.5f;
                    }
					else
                    {
						AddToPlayer(_player, skillToAdd.GetType());
                    }
					break;
                }

            default:
				{
					Debug.Log("Error, has no such skill");
					break;
				}
		}
	  
	}

	private void AddToPlayer(GameObject player, Type skill)
	{
		player.AddComponent(skill);
	}
}
