using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class NewPowersSkill : Skill
{
    [SerializeField] private float _healthToAdd = 10;
    [SerializeField] private SkillData _skillData;
    private void Start()
    {
        SkillMechanic();
    }

    public override void SkillMechanic()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.IncreaseMaxHealth(_healthToAdd);
    }


}
