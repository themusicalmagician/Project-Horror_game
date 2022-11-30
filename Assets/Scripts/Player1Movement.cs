using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    //public Animator animator;

    public float speed;
    public float jumpForce;
    private float moveInput;

    public int maxHealth = 100;
    public int health;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;

    public bool KnockFromRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void FixedUpdate()
    {
        if (KBcounter <= 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBforce, 10);
            }

            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBforce, 10);
            }

            KBcounter -= Time.deltaTime;
        }

        //animator.SetFloat("Speed", Mathf.Abs(moveInput));
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void Update()
    {
        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = 10;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 5;
        }
        
        //jumping
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //turn character around on movement
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
