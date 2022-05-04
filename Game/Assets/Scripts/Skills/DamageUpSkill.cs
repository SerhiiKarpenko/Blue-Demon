using UnityEngine;

public class DamageUpSkill : MonoBehaviour
{
    [SerializeField] private float _damageToAdd = 10;
    [SerializeField] private SkillData _skillData;

    private void Start()
    {
        SkillMechanic();
    }

    private void SkillMechanic()
    {
        SwortAtack swortAtack = gameObject.GetComponentInChildren<SwortAtack>();
        swortAtack.IncreaseSwordDamage(_damageToAdd);
    }
}
