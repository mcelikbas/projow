using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inputX;
    [SerializeField] private int maxJump = 2;
    private int nbOfJumpAllowed;

    PlayerPhysics playerPhysics;


    void Start ()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
        nbOfJumpAllowed = maxJump;
    }

    void Update ()
    {
        if (playerPhysics.isGrounded)
        {
            nbOfJumpAllowed = maxJump;
        }

        if (nbOfJumpAllowed > 0 && Input.GetButtonDown("Jump"))
        {
            playerPhysics.Jump(--nbOfJumpAllowed);
        }
    }

    private void FixedUpdate ()
    {
        inputX = Input.GetAxis("Horizontal");
        playerPhysics.Move(inputX);
    }
}
