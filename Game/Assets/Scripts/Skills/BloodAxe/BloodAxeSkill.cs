using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectForSkillsHolder))]
public class BloodAxeSkill : Skill
{
	private float _rotationSpeed = 170;
	private float _timeToAxeAppear = 5.0f;
	private float _timeOfAxeRotating = 2.0f;
	private Vector3 _offset = new Vector3(0, 2, 0);
	private GameObject _axe;
	private GameObject _player;
	private GameObject _axeClone;
	private ObjectForSkillsHolder _objectForSkillsHolder;
	private Collider2D _axeCollider;
	private Collider2D _playerCollider;
	private bool _rotate = false;

	private void Start()
	{
		SetObjectsAndComponents();
		SetColliders();
		StartCoroutine(SkillMechanicNumerator());
	}

    private void Update()
    {
		IgnorePlayerCollider();
		RotateAxe();
    }

    public override IEnumerator SkillMechanicNumerator()
	{
		while(true)
		{
			yield return new WaitForSeconds(_timeToAxeAppear);
			_axeClone.SetActive(true);
			_rotate = true;
			yield return new WaitForSeconds(_timeOfAxeRotating);
			_axeClone.SetActive(false);
			_rotate = false;
			
		}
	}


	private void RotateAxe()
    {
		if(_rotate)
			 _axeClone.transform.RotateAround(_player.transform.position, Vector3.back, _rotationSpeed * Time.deltaTime);
	}

	private void IgnorePlayerCollider()
    {
		Physics2D.IgnoreCollision(_axeCollider, _playerCollider, true);
    }

	private void SetObjectsAndComponents()
    {
		_player = gameObject;
		_objectForSkillsHolder = _player.GetComponent<ObjectForSkillsHolder>();
		_axe = _objectForSkillsHolder.Axe;
		_axeClone = Instantiate(_axe, _player.transform.position + _offset, Quaternion.identity);
		_axeClone.transform.SetParent(_player.transform);
		_axeClone.SetActive(false);
	}

	private void SetColliders()
    {
		_axeCollider = _axeClone.GetComponent<Collider2D>();
		_playerCollider = _player.GetComponent<Collider2D>();
    }

}
