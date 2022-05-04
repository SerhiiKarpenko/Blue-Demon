using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class NewPowersSkill : MonoBehaviour
{
    [SerializeField] private float _healthToAdd = 10;
    private void Start()
    {
        SkillMechanic();
    }

    private void SkillMechanic()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.IncreaseMaxHealth(_healthToAdd);
    }
}
