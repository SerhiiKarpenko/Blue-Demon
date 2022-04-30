using UnityEngine;

public class EnemyHealth : HealthAbstract
{
	[SerializeField] private GameObject _experienceStone;
	[SerializeField] private float _currentHealth;
	private float _maxHealth;
	private Experience _experience;

    public float MaxHealth => _maxHealth;
	public float CurrentHealth => _currentHealth;


	public override void ApplyDamage(float amount)
	{
		if(amount < 0)
		{
			throw new System.ArgumentOutOfRangeException("Damage is negative, cannot apply negative Damage");
		}
		_currentHealth -= amount;
		if(_currentHealth <= 0)
		{
			Death();
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
		gameObject.SetActive(false);
		GameObject stone = Instantiate(_experienceStone, transform.position, Quaternion.identity);
		_experience = stone.GetComponent<Experience>();
		_experience.SetAmount(GetComponent<Enemy>().AmountOfExperienceToDrop);
	}


}