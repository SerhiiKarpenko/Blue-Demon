using UnityEngine;

public class SwortAtack : MonoBehaviour
{
    [SerializeField] private float _swordDamage;
    

    private void Start()
    {
        _swordDamage = GetComponent<SwordStats>().SetDamage();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyHealth EnemyHealth;
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth = collision.GetComponent<EnemyHealth>();
            EnemyHealth.ApplyDamage(_swordDamage);
        }
    }

    public void IncreaseSwordDamage(float swordDamage)
    {
        _swordDamage += swordDamage;
    }

}
