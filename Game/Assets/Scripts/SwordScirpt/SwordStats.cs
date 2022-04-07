using UnityEngine;

public class SwordStats : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _rotationSpeed;

    public float Damage => _damage;
    public float RotationSpeed => _rotationSpeed;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }
}
