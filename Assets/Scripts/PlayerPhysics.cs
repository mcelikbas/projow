using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float jumpForce = 3.0f;
    private bool isFacingRight = true;
    public bool isGrounded;
    public bool airControl = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private const float groundedCheckRadius = 0.2f;

    private Rigidbody2D rb2d;


    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate ()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedCheckRadius, whatIsGround);
    }

    public void Move (float inputX)
    {
        if (isGrounded || airControl)
        {
            rb2d.velocity = new Vector2(inputX * maxSpeed, rb2d.velocity.y);
        }

        if (inputX > 0 && !isFacingRight || inputX < 0 && isFacingRight)
        {
            Flip();
        }
    }


    public void Jump (int nbOfJumpAllowed)
    {
        if (isGrounded)
        {
            isGrounded = false;
        }
        if (nbOfJumpAllowed > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private void Flip ()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
