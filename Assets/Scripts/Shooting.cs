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
    public float timer;
    private bool bulletup;
    public float firerate;

    public bool can_fire = false;

    void Start() 
    {
        shootSound = GetComponent<AudioSource>();
        timer = Time.time;
        bulletup = true;
        firerate = 0.4f;
    }
    void Update()
    {
        if (can_fire && Input.GetButton("Fire1") && bulletup)
        {
            Shoot();
            bulletup = false;
        }
        if (Time.time - timer > firerate)
        {
            timer = Time.time;
            bulletup = true;
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
