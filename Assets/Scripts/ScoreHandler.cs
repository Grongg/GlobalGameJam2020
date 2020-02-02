using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int startingScore = 0;
    private int currentScore;
    public TextMeshProUGUI scoretxt;

    private void Start()
    {
        currentScore = startingScore;
        displayScore();
    }
    public void setScore(int score)
    {
        currentScore = score;
        displayScore();
    }

    public int getScore()
    {
        return currentScore;
    }

    public void displayScore()
    {
        scoretxt.text = "Score: " + currentScore.ToString();
    }

    public void resetScore()
    {
        setScore(0);
        displayScore();
    }

    public void addPoints(int points)
    {
        currentScore += points;
        displayScore();
    }
}
