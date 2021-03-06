﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    private AudioSource shieldDamaged;
    public HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            healthBar.doDamage(10);
            Destroy(collision.gameObject);
            shieldDamaged.Play(0);
        }
    }
    void Start()
    {
        shieldDamaged = GetComponent<AudioSource>();
        //healthBar.displayHealth();
//        repairBar.doRepair(1);
    }
    private void Update()
    {
        if (healthBar.getHealth() == 0)
        {
            SceneManager.LoadScene("EndGameScreen", LoadSceneMode.Single);
        }
    }
}
