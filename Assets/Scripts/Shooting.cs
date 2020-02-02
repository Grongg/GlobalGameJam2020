using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private AudioSource shootSound;
    public float bulletForce = 20f;

    public bool can_fire = false;

    void Start() 
    {
        shootSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (can_fire && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        shootSound.Play(0);
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
