using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public ScoreHandler score;
    void Start()
    {
        score.addPoints(1);    
    }

    void Update()
    {
        score.addPoints(1);
    }
}
