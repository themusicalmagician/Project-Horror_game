using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1000;
    //public GameObject deathEffect;

    public float moveSpeed;
    public int patrolDestination;
    private float dirX;

    public Transform player1Transform;
    public bool isChasing;
    public float chaseDistance;

    [SerializeField] private GameObject gotchaText;
    private Rigidbody2D rb;

    void Start()
    {
        gotchaText.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    void Update()
    {
        if (isChasing)
        {
            if (transform.position.x > player1Transform.position.x)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < player1Transform.position.x)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, player1Transform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (transform.position.x < -15f)
                dirX = 1f;
            if (transform.position.x > -10f)
                dirX = -1f;

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            gotchaText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            gotchaText.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
