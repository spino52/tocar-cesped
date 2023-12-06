using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moventplayer : MonoBehaviour
{


        private float horizontal;
    private float speed = 8f;
    private float jumpingpawer = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;


 // Update is called once per frame
    void Update()

    {
        horizontal = Input.GetAxisRaw("horizontal");

        if (Input.GetButtonDown("jump")&& IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpawer);
        }

        if (Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
        }

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer); 
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
       
    }
}

