using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Transform bar;
    public TextMeshProUGUI txtHealth;
    private float currentHealth = 100f;
    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, .5f);
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
        Debug.Log(currentHealth);
        if (currentHealth - dmg <= 0)
        {
            setHealth(0);
            Debug.Log("U're dead");//code death func
        }
        else
        {
            if (currentHealth <= 25f)
                setColor(Color.red);
            Debug.Log(currentHealth);
            setHealth(currentHealth - dmg);
        }
    }
}
