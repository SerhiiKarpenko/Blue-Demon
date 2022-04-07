using UnityEngine;

public class PlayerHealth : HealthAbstract
{
	[SerializeField] private float _currentHealth;
	[SerializeField] private float _maxHealth;
	public delegate void ChangeHealthBarValue(float currentHealth);
	public delegate void OnDeath();
	public static event ChangeHealthBarValue onChangeHp;
	public static event OnDeath OnDeathEvent;
	

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
		gameObject.SetActive(false);
		OnDeathEvent.Invoke();
	}


	// ������� ? 
	public void Heal()
	{
		// ���� ����� ����� �� ������� �� ���������� 2 ������, �������� �������� ����������� 
	}


}