using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
	[SerializeField] private Slider _healthBar;

	private void Start()
	{
		OnStartGame(GetComponent<PlayerHealth>().MaxHealth);
		PlayerHealth.onChangeHp += OnPlayerHealthPointsChange;
	}

    private void Update()
    {
		Debug.Log(_healthBar.value);
    }

    public void OnPlayerHealthPointsChange(float newHealth) => _healthBar.value = newHealth;
	public void OnStartGame(float maxHp)
	{
		_healthBar.maxValue = maxHp;
		_healthBar.value = _healthBar.maxValue;
	}
}
