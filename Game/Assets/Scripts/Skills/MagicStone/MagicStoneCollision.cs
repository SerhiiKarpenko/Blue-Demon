using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneCollision : MonoBehaviour
{
    private float _magicStoneDamage = 2.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.ApplyDamage(_magicStoneDamage);
            Destroy(gameObject);
        }
    }
}
