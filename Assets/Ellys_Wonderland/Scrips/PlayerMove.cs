using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
