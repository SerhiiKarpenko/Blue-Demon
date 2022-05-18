using UnityEngine;

[RequireComponent(typeof(PlayerLevel))]
public class PlayerHealth : HealthAbstract
{
	[SerializeField] private AudioClip _deathSound;
	[SerializeField] private GameObject _deathEffect;
	[SerializeField] private GameObject _playerUI;
	[SerializeField] private float _currentHealth;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _healPower;
	[SerializeField] private float _timeWaitToHeal;
	private float _timer;
	private PlayerLevel _currentLevel;
	public bool isAtacked = false;
	public delegate void ChangeHealthBarValue(float currentHealth);
	public static event ChangeHealthBarValue onChangeHp;

	public float MaxHealth => _maxHealth;
	public float CurrentHealth => _currentHealth;

	private void Awake()
    {
		_timer = _timeWaitToHeal;
    }

    private void Start()
	{
		_currentLevel = gameObject.GetComponent<PlayerLevel>();
		_currentHealth = _maxHealth;
	}

	private void Update()
	{
		// if player is not atacked _timeWaitToHeal second's, then HEAL 
		if(!isAtacked && _currentHealth < MaxHealth)
        {
			_timer -= Time.deltaTime;
			if(_timer <= 0)
            {
				Heal();
            }
        }
		else
        {
			_timer = _timeWaitToHeal;
        }
	}

	public override void ApplyDamage(float amount)
	{
		if(amount < 0)
		{
			throw new System.ArgumentOutOfRangeException("Cannot apply negative Damage");
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
		if (gameObject.TryGetComponent(out AngelSkill angelSkill))
		{
			angelSkill.SkillMechanic();
			Destroy(angelSkill);
		}
		else
		{
			AudioManager.Instance.Play(_deathSound.name);
			Instantiate(_deathEffect, transform.position, Quaternion.identity);
			Events.OnPlayerDeath();
			gameObject.SetActive(false);
			_playerUI.SetActive(false);
			PlayerPrefs.SetInt("Player_level", _currentLevel.CurrentLevel);
		}
	}


	private void Heal()
	{
		if (_currentHealth + _healPower > _maxHealth)
		{
			_currentHealth = _maxHealth;
			onChangeHp?.Invoke(_currentHealth);
		}
		else
		{
			_currentHealth += _healPower;
			onChangeHp?.Invoke(_currentHealth);
		}
	}

	public void IncreaseMaxHealth(float maxHealth)
    {
		_maxHealth += maxHealth;
    }

	public void SetCurrentHealth(float health)
    {
		_currentHealth = health;
		onChangeHp?.Invoke(_currentHealth);
    }


	
}
