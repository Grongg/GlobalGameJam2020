using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBar repairBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        healthBar.doDamage(10);
    }
    void Start()
    {
        //healthBar.displayHealth();
        healthBar.doDamage(1);
        repairBar.doRepair(3);
    }
}
