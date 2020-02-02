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
        DataCollector.Score = currentScore;
        displayScore();
    }
    public void setScore(int score)
    {
        currentScore = score;
        DataCollector.Score = currentScore;
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
        DataCollector.Score = currentScore;
        displayScore();
    }

    public void addPoints(int points)
    {
        currentScore += points;
        DataCollector.Score += points;
        displayScore();
    }
}
