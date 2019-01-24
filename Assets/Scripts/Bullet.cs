using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    //public GameObject impactEffect;

    private PlayerPhysics playerPhysics;


    void Start()
    {
        playerPhysics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhysics>();

        if (playerPhysics.isFacingRight)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -transform.right * speed;
        }
       
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        

        if (hitInfo.CompareTag("enemy"))
        {
            hitInfo.GetComponent<Enemy>().TakeDamage(damage);
            
        }

        //Instantiate(impactEffect, transform.position, transform.rotation); 

        Destroy(gameObject);
    }


}
