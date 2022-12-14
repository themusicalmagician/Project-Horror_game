using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float dirX;
    float moveSpeed = 8f;

    public int maxHealth = 100;
    public int health;

    public Animator animator;

    void Start()
    {
        health = maxHealth;
    }

    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(dirX));
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + dirX * moveSpeed * Time.deltaTime, transform.position.y);

        if (dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (dirX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveSpeed = 15f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed = 8f;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
