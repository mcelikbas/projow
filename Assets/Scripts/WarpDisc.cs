using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpDisc : MonoBehaviour
{
    private Item warpDisc;
    public bool isLaunched = false;
    private Vector2 lastPosition;
    public float distanceTraveled = 0.0f;
    private float MaxTravelDistance = 3.0f;
    private float speed = 10.0f;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2d;
    private Rigidbody2D rb2d;
    private PlayerItems playerItems;
    private PlayerPhysics playerPhysics;
    private GameObject player;


    void Start ()
    {
        warpDisc = new Item("Warp Disc", "Allow the player to teleport");
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2d = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        playerItems = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();
        playerPhysics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhysics>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        if (isLaunched && distanceTraveled < MaxTravelDistance)
        {
            distanceTraveled += Vector2.Distance(transform.position, lastPosition);
        }

        if (Input.GetButton("WarpDisc") && playerItems.items.Contains(warpDisc))
        {
            playerItems.equippedItem = warpDisc;
        }
        if (Input.GetButtonDown("ActivateItem") && playerItems.equippedItem == warpDisc && !isLaunched)
        {
            throwDisc();
        }
        else if (Input.GetButtonDown("ActivateItem") && playerItems.equippedItem == warpDisc && isLaunched)
        {
            teleportToDisc();
        }
    }

    private void FixedUpdate ()
    {
        if (isLaunched)
        {
            if (distanceTraveled < MaxTravelDistance)
            {
                activateDisc();
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerItems.items.Contains(warpDisc))
            {
                if (!isLaunched)
                {
                    deactivateDisc();
                }
            }
            else
            {
                playerItems.items.Add(warpDisc);
                deactivateDisc();
            }
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (rb2d.velocity.x == 0 && collision.gameObject.layer == 8) // layer ground
        {
            Debug.Log("hit ground");
            deactivateDisc();
            isLaunched = false;
            distanceTraveled = 0.0f;
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    private void throwDisc ()
    {
        isLaunched = true;
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.Find("disc start position").position;
        lastPosition = transform.position;
        if (playerPhysics.isFacingRight)
        {
            speed = Mathf.Abs(speed);
        }
        else if (!playerPhysics.isFacingRight)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void teleportToDisc ()
    {
        playerPhysics.teleport(transform.position);
        isLaunched = false;
        distanceTraveled = 0.0f;
    }


    private void activateDisc ()
    {
        spriteRenderer.enabled = true;
        circleCollider2d.enabled = true;
    }

    private void deactivateDisc ()
    {
        spriteRenderer.enabled = false;
        circleCollider2d.enabled = false;
    }
}
