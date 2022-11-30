using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float dirX;
    public float moveSpeed;
    public float jumpForce;

    public int maxHealth = 100;
    public int health;

    public bool isGrounded;
    public Transform GroundCheck;

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + dirX * moveSpeed * Time.deltaTime, transform.position.y);
    }
}
