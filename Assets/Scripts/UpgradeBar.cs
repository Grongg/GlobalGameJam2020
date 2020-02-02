using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    public Transform bar;

    private int startingUpgrade = 1;
    private int currentUpgrade = 0;
    private int maxupgrade = 5;
    private float barState = 1f;

    private void Start()
    {
        currentUpgrade = startingUpgrade;
        bar = transform.Find("Bar");
        //setInitSize();TOFIX -> done but we need to do upgrade for this to work
    }
    public int getCurrentUpgrade()
    {
        return currentUpgrade;
    }

    public void setInitSize()
    {
        bar.localScale = new Vector3(0.20f, 0.54f);
    }

    public void upgradeSize()
    {
        Debug.Log("here3");
        Debug.Log(barState * 0.20f);
        bar.localScale = new Vector3(barState * 0.20f, 0.54f);
    }
    public void upgrade()
    {
        Debug.Log("here");
        if (currentUpgrade + 1 <= maxupgrade)
        {
            Debug.Log("here2");
            barState++;
            currentUpgrade++;
            upgradeSize();
        }
    }

    void Update()
    {
        
    }
}
