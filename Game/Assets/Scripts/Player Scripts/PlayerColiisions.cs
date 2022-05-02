using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerLevel))]
public class PlayerColiisions : MonoBehaviour
{
	private PlayerLevel _playerLevel;
	private PlayerHealth _playerHealth;

	private void Start()
	{
		_playerLevel = GetComponent<PlayerLevel>();
		_playerHealth = GetComponent<PlayerHealth>();
	}

	private void FixedUpdate()
	{
		CheckIsMonstersInOverlapBox();  
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.GetComponent<Experience>() != null)
		{
			float amount = collision.gameObject.GetComponent<Experience>().Amount;
			Events.OnPlayerLevelUp();
			_playerLevel.UpdateCurrentExperienceValue(amount);
			Destroy(collision.gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.GetComponent<Enemy>() != null)
		{
			GetComponent<PlayerHealth>().ApplyDamage(collision.gameObject.GetComponent<Enemy>().Damage);
			collision.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0);
			_playerHealth.isAtacked = true;
			
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
	}

	private void CheckIsMonstersInOverlapBox()
	{
		Collider2D collider = Physics2D.OverlapBox(gameObject.transform.position, transform.localScale / 2, 0f);
		if (collider.gameObject.GetComponent<Enemy>() == null)
		{
			_playerHealth.isAtacked = false;
		}
		else
		{
			_playerHealth.isAtacked = true;
		}
        
		//Debug.Log(colliders.name);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}
}
