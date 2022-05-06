using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(ObjectForSkillsHolder))]
public class AngelSkill : Skill
{
    private ObjectForSkillsHolder _objectForSkillsHolder;
    private PlayerHealth _playerHealth;
    private Vector3 _offset = new Vector3(0,-2,0);
    private GameObject _angelPrefab;
    

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _objectForSkillsHolder = GetComponent<ObjectForSkillsHolder>();
        _angelPrefab = _objectForSkillsHolder.Angel;
    }

    public override void SkillMechanic()
    {
        _playerHealth.SetCurrentHealth(_playerHealth.MaxHealth);
        Instantiate(_angelPrefab, gameObject.transform.position + _offset, Quaternion.identity);
        
    }
}
