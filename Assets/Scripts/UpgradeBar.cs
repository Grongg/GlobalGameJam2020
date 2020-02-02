using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    public Transform bar;

    private int startingUpgrade = 0;
    private int currentUpgrade = 0;
    private int maxupgrade = 5;
    private float barState = 0f;

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
        bar.localScale = new Vector3(0f, 0.54f);
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
            upgradeSize();
            currentUpgrade++;
            barState++;
        }
    }

    void Update()
    {
        
    }
}
