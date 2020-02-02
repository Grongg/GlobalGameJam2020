﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Transform bar;
    public TextMeshProUGUI txtHealth;
    private float startingHealth;
    private float currentHealth;
    private float maxHealth = 100;
    public bool repairMode;
    private void Start()
    {
        if (repairMode == true)
        {
            startingHealth = 0;
            setColor(Color.white);
        }
        else
            startingHealth = 100;
        currentHealth = startingHealth;
        setHealth(currentHealth);
        displayHealth();
        bar = transform.Find("Bar");
    }

    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, .54f);
    }

    public void setColor (Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }

    public void setHealth(float health)
    {
        currentHealth = health;
        displayHealth();
        setSize(health * 0.01f);
    }

    public void displayHealth()
    {
        txtHealth.text = ((int)currentHealth).ToString();
    }
    
    public float getHealth()
    {
        return currentHealth;
    }

    public void doDamage(float dmg)
    {
        if (currentHealth - dmg <= 0)
        {
            setHealth(0);
        }
        else
        {
            setHealth(currentHealth - dmg);
            if (currentHealth <= (startingHealth * 0.25))
                setColor(Color.red);
        }
    }
    public void doRepair(float repair)
    {
        if (currentHealth + repair >= maxHealth)
        {
            setHealth(currentHealth + repair);
            Debug.Log("Ship repaired");
        }
        else
        {
            setHealth(currentHealth + repair);
        }
    }
}
