using UnityEngine;
using System;

public class DamageUpSkill : Skill
{
    [SerializeField] private float _damageToAdd = 0.1f;
    [SerializeField] private SkillData _skillData;

    private void Start()
    {
        SkillMechanic();
    }

    public override void SkillMechanic()
    {
        SwortAtack swortAtack = gameObject.GetComponentInChildren<SwortAtack>();
        swortAtack.IncreaseSwordDamage(_damageToAdd);
    }
}
