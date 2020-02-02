using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairEngine : MonoBehaviour
{
    public HealthBar repairBar;
    private bool state = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Player")
        {
            repairBar.doRepair(0.1f);
        }
    }

    void Start()
    {
        DataCollector.State = state;
    }

    void Update()
    {
    }
}
