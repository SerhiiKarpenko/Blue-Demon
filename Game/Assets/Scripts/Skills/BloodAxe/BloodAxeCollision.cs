using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodAxeCollision : MonoBehaviour
{
    private float _axeDamage = 0.1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.ApplyDamage(_axeDamage);
        }
    }
}
