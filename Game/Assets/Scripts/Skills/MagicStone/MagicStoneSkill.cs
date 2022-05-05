using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneSkill : Skill
{
	private float _timeToMagicStoneAppear = 10.0f;
	private float _timer;
	private Vector3 _offset = new Vector3(0, 2, 0);
	private GameObject _magicStonePrefab;
	private GameObject _player;
	private ObjectForSkillsHolder _objectForSkillsHolder;

    private void Awake()
    {
		_timer = _timeToMagicStoneAppear;
    }

    private void Start()
	{
		SetObjectAndComponents();
		//StartCoroutine(SkillMechanicNumerator());
	}

    private void Update()
    {
		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			SkillMechanic();
			_timer = _timeToMagicStoneAppear;
		}
    }

    public override void SkillMechanic()
	{
		if (EnemiesList.Instance.Enemies.Count > 0)
		{
			Instantiate(_magicStonePrefab, _player.transform.position + _offset, Quaternion.identity);
		}
	}

	public override IEnumerator SkillMechanicNumerator()
	{
		while(true)
		{
			if (EnemiesList.Instance.Enemies.Count > 0)
			{
				yield return new WaitForSeconds(_timeToMagicStoneAppear);
				Instantiate(_magicStonePrefab, _player.transform.position + _offset, Quaternion.identity);
			}

		}
	}

	private void SetObjectAndComponents()
	{
		_player = gameObject;
		_objectForSkillsHolder = gameObject.GetComponent<ObjectForSkillsHolder>();
		_magicStonePrefab = _objectForSkillsHolder.MagicStone;

	}
}
