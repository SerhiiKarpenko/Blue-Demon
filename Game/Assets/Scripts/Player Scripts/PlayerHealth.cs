using UnityEngine;

public class PlayerHealth : HealthAbstract
{
	[SerializeField] private float _currentHealth;
	[SerializeField] private float _maxHealth;
	public delegate void ChangeHealthBarValue(float currentHealth);
	public static event ChangeHealthBarValue onChangeHp;

	public float MaxHealth => _maxHealth;

	private void Start()
	{
		_currentHealth = _maxHealth;
	}

	public override void ApplyDamage(float amount)
	{
		if(amount < 0)
		{
			throw new System.ArgumentOutOfRangeException("Cannot apply negative damage");
		}

		if (_currentHealth <= 0)
		{
			Death();
		}
		_currentHealth -= amount;
		onChangeHp?.Invoke(_currentHealth);
	}

	public override void Death()
	{
		base.Death();
	}


	// корутин ? 
	public void Heal()
	{
		// если героя никто не ударяет на протяжении 2 секунд, здоровье начинает восполнятся 
	}


}
