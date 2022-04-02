using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiisions : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            GetComponent<PlayerHealth>().ApplyDamage(collision.gameObject.GetComponent<Enemy>().Damage);
            collision.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
}
