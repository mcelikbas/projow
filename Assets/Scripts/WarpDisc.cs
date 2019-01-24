using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpDisc : MonoBehaviour
{
    private Item warpDisc;
    public bool isLaunched = false;
    //private Vector2 thrownDistance = new Vector2(10.0f, 0.0f);
    private float speed = 3.0f;


    public Transform discStartPosition;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2d;
    private Rigidbody2D rb2d;
    private PlayerItems playerItems;
    private PlayerPhysics playerPhysics;
    private GameObject player;
    
    
    void Start()
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
        if (Input.GetButton("WarpDisc") && playerItems.items.Contains(warpDisc))
        {
            playerItems.equippedItem = warpDisc;
        }
        if (Input.GetButtonDown("ActivateItem") && playerItems.equippedItem == warpDisc && !isLaunched)
        {
            isLaunched = true;
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
            throwDisc();
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            circleCollider2d.enabled = false;
            if (!playerItems.items.Contains(warpDisc))
            {
                playerItems.items.Add(warpDisc);
            }
        }
    }


    private void throwDisc ()
    {
        spriteRenderer.enabled = true;
        circleCollider2d.enabled = true;

        Vector2 velocity = new Vector2(speed, 0);

        Vector2 thrownPos = new Vector2(discStartPosition.position.x, discStartPosition.position.y);
        if (playerPhysics.isFacingRight)
        {
            //thrownDistance.x = Mathf.Abs(thrownDistance.x);
        }
        else if (!playerPhysics.isFacingRight)
        {
            //thrownPos.x = -discStartPosition.position.x;
            //thrownDistance.x = -thrownDistance.x;
        }
        //rb2d.MovePosition(thrownPos + thrownDistance*Time.fixedDeltaTime);

        rb2d.velocity = velocity;
    }


    private void teleportToDisc ()
    {
        playerPhysics.teleport(transform.position);
        isLaunched = false;
    }
}
