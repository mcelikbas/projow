using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           
            Shoot();
        }
       

    }

    void Shoot ()
    {
        animator.SetTrigger("shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
