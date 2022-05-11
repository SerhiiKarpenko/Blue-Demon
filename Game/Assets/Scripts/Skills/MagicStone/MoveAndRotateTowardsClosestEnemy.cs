using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateTowardsClosestEnemy : MonoBehaviour
{
    private float _speed = 0.0f;
    private Transform _closestEnemy;

    void Start()
    {
        _closestEnemy = GetClosestToPlayerEnemy();
    }

    void Update()
    {
        MoveTowardsClosestEnemy();
        RotateTowardsClosestEnemyEnemy();
    }

    private void MoveTowardsClosestEnemy()
    {
        if (_closestEnemy.gameObject == null)
        {
            Destroy(gameObject);
            return;
        }
        if(_closestEnemy == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _closestEnemy.transform.position, _speed * Time.deltaTime);
    }

    private void RotateTowardsClosestEnemyEnemy()
    {
        if (_closestEnemy == null)
        { 
            return;
        }
        Vector3 directionToFace = _closestEnemy.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, directionToFace);
    }

    private Transform GetClosestToPlayerEnemy()
    {
        Transform closestEnemy = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject g in EnemiesList.Instance.Enemies)
        {
            float dist = Vector3.Distance(g.transform.position, gameObject.transform.position);
            if (dist < minDist)
            {
                closestEnemy = g.transform;
                minDist = dist;
            }
        }

        return closestEnemy;
    }
}
