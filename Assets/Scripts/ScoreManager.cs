using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 300;
    private const string scoreKey = "PlayerScore";

    void Start()
    {
        
        LoadScore();
        
    }

    public void AddPoints(int points)
    {
        score += points;
        PlayerPrefs.SetInt(scoreKey, score);
        UpdateScoreText();
        if (score <= 0)
        {
        }
        if (score >= 1000)
        {
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Saldo: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 300;
        PlayerPrefs.SetInt(scoreKey, score);
        UpdateScoreText();
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey(scoreKey))
        {
            score = PlayerPrefs.GetInt(scoreKey);
        }
        else
        {
            score = 300;
        }
        UpdateScoreText();
    }
}