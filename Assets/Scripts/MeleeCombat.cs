using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    //public Animator animator;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemylayers;

    public int damage = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        //animator.SetTrigger("Attack");

        //Detect enemies in Range
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemylayers);


        //Do Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
