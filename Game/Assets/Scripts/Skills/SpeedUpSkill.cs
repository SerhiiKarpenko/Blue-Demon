using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class SpeedUpSkill : Skill
{
    [SerializeField] private float _speedToAdd = 1;
    [SerializeField] private SkillData _skillData;

    private void Start()
    {
        SkillMechanic();
    }
    public override void SkillMechanic()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.IncreasePlayerMoveSpeed(_speedToAdd);
    }
}
