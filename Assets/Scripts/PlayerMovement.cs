using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics playerPhysics;
    private float inputX = 0.0f;
    public float speed = 10.0f;
    public bool jump = false;
    public float jumpForce = 5.0f;

    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        
    }

    private void FixedUpdate ()
    {
        playerPhysics.Move(speed * inputX * Time.deltaTime, jumpForce, jump);
    }
}
