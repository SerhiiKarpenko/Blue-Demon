using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateTowardsClosestEnemy : MonoBehaviour
{
    private float _speed = 7.0f;
    private float _rotationSpeed = 60f;
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
        transform.position = Vector3.MoveTowards(transform.position, _closestEnemy.transform.position, _speed * Time.deltaTime);
    }

    private void RotateTowardsClosestEnemyEnemy()
    {
        Vector3 directionToFace = _closestEnemy.position - transform.position;
       // Vector3 rotatedDirectionToFace = Quaternion.Euler(0, 0, 90) * directionToFace;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, directionToFace);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    
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
