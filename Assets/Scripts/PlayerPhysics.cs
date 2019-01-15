using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool isGrounded = false;
    //public float jumpForce = 10.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    public void Move(float speed, float jumpForce, bool jump)
    {
        //transform.Translate(moveRate, 0);
        if (!jump)
        {
            jumpForce = 0;
        }
        rb2d.velocity = new Vector2(speed, jumpForce);
    }
}
