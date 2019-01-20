using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isFacingRight = true;
    [SerializeField] private float maxSpeed = 3f;
    public bool isGrounded;
    [SerializeField] private float jumpForce = 20f;


    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move (float inputX, bool isJumping)
    {
        if (isGrounded)
        {
            rb2d.velocity = new Vector2(inputX * maxSpeed, rb2d.velocity.y);

            if (inputX > 0 && !isFacingRight || inputX < 0 && isFacingRight)
            {
                Flip();
            }
        }

        if (isGrounded && isJumping)
        {
            isGrounded = false;
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
    }


    public void OnCollisionEnter2D (Collision2D other)
    {
        // is it grounded?
        if (other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    public void OnCollisionStay2D (Collision2D other)
    {
        // is it grounded?
        if (other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    private void Flip ()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
