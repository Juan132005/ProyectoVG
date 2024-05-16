using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    private int score = 1000;
    private const string scoreKey = "PlayerScore";
    public Seleccionar seleccionar;

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
            SceneManager.LoadScene(2);
        }
        if (score >= 1000)
        {
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Saldo: " + score.ToString();
        scoreText2.text = "Saldo: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 1000;
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
            score = 1000;
        }
        UpdateScoreText();
    }
}