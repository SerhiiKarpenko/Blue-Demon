using UnityEngine;

public class EnemyHealth : HealthAbstract
{
    [SerializeField] private float _currentHealth;
    private float _maxHealth;

    public override void ApplyDamage(float amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage is negative, cannot apply negative damage");
        }

        if(_currentHealth - amount < 0)
        {
            Death();
        }
        else
        {
            _currentHealth -= amount;
        }
    }

    public void SetHealth(float maxHealth, float currentHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
    }

    public override void Death()
    {
        base.Death();
    }


}