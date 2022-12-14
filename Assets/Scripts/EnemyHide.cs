using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHide : MonoBehaviour
{
    private float dirX;
    private float moveSpeed = 7f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       // gotchaText.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 30f)
            dirX = 1f;
        if (transform.position.x > 40f)
            dirX = -1f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            SceneManager.LoadScene(2);
    }
}
