using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics playerPhysics;

    [SerializeField]
    private bool isJumping = false;


    void Start ()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    void Update ()
    {
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate ()
    {
        float inputX = Input.GetAxis("Horizontal");
        playerPhysics.Move(inputX, isJumping);
        isJumping = false;
    }
}
