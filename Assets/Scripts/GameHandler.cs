using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private float time = 0.0f;
    private float health = 1f;
    void Update()
    {
        if (time > .03f)
        {
            if (health > .01f)
            {
                health -= .01f;
                healthBar.SetSize(health);

                if (health < .25f)
                {
                    if ((health * 100f) % 3 <= 1.000072)
                    {
                        healthBar.SetColor(Color.white);
                    }
                    else
                    {
                        healthBar.SetColor(Color.red);
                    }
                }
            }
            time = 0;
        }
        time += Time.deltaTime;
    }
}
 