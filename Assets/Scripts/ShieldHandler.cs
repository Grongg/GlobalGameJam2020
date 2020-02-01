using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthBar.doDamage(10);
    }
    void Start()
    {
        //healthBar.displayHealth();
        healthBar.doDamage(1);
    }
}
