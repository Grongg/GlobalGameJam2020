using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI statetxt;
    public TextMeshProUGUI scoretxt;
    private void Start()
    {
        scoretxt.text = "Score: " + DataCollector.Score.ToString();
    }

    private void Update()
    {
        if (DataCollector.State == true)
        {
            statetxt.text = "You Win and escaped!";
        }
        else
        {
            statetxt.text = "You Lost and died!";
        }
    }
}
