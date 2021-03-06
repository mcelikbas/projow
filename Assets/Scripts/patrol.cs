﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance = 1f;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        //RaycastHit2D rightWallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);
       //RaycastHit2D leftWallInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);

        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}
