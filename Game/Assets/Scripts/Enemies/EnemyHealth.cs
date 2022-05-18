using UnityEngine;

public class EnemyHealth : HealthAbstract
{
	[SerializeField] private GameObject _deathEffect;
	[SerializeField] private GameObject _experienceStone;
	[SerializeField] private float _currentHealth;
	[SerializeField] private AudioClip _death�lip;
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
		EnemiesList.Instance.Enemies.Remove(gameObject);
		//AudioSource.PlayClipAtPoint(_deathS, transform.position);
		AudioManager.Instance.Play(_death�lip.name);
		base.Death();
		gameObject.SetActive(false);
		Instantiate(_deathEffect, transform.position, Quaternion.identity);
		GameObject stone = Instantiate(_experienceStone, transform.position, Quaternion.identity);
		_experience = stone.GetComponent<Experience>();
		_experience.SetAmount(GetComponent<Enemy>().AmountOfExperienceToDrop);
		Events.OnKilledEnemyCounterRisedUp();
	}
}