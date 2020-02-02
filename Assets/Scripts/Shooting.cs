using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private AudioSource shootSound;
    public KeyCode fireKey;
    public float bulletForce = 20f;
    // Update is called once per frame
    void Start() 
    {
        shootSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
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
