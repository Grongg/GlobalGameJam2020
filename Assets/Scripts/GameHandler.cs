﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    void Start()
    {
        healthBar.setSize(1f);
        healthBar.displayHealth();
        healthBar.setColor(Color.green);
    }
    void Update()
    {
        healthBar.doDamage(10);
    }
}
 