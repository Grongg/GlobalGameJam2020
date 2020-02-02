using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBar repairBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            healthBar.doDamage(10);
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        //healthBar.displayHealth();
//        repairBar.doRepair(1);
    }
}
