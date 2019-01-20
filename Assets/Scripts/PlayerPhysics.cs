using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float jumpForce = 3.0f;
    public bool isFacingRight = true;
    public bool isGrounded;
    public bool airControl = true;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private const float groundedCheckRadius = 0.2f;

    private Rigidbody2D rb2d;
    private Animator animator;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate ()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedCheckRadius, whatIsGround);

        
    }

    public void Move (float inputX)
    {
        if (inputX == 0)
        {
            animator.SetBool("isRunning", false);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        else if (inputX != 0 && isGrounded || airControl)
        {
            rb2d.velocity = new Vector2(inputX * maxSpeed, rb2d.velocity.y);
            animator.SetBool("isRunning", true);
        }

        if (inputX > 0 && !isFacingRight || inputX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip ()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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

    public void teleport (Vector2 toPosition)
    {
        transform.position = toPosition;
    }

    public void dash ()
    {
        Vector2 velocity = new Vector2(10f, 0f);
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }


}
