using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public Player1Movement playerHealth;
    public Player1Movement knockback;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            knockback.KBcounter = knockback.KBtotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knockback.KnockFromRight = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                knockback.KnockFromRight = false;
            }

            playerHealth.TakeDamage(damage);
        }
    }

    
}
