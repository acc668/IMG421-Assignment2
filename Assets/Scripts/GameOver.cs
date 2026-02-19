using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Text resultText;
    public Text scoreText;
    public Text highScoreText;
    public Text difficultyText;
    public Button mainMenuButton;
    public Button playAgainButton;

    private bool   didWin;
    private int    finalScore;
    private string difficultyName;
    private int    highScore;

    void Awake()
    {
        didWin        = GameResult.playerWon;
        finalScore    = GameResult.finalScore;
        difficultyName = GameManager.GetDifficultyName();
        highScore     = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        Debug.Log("Awake — didWin: " + didWin + " finalScore: " + finalScore + " difficulty: " + difficultyName);
    }

    void Start()
    {
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        if (playAgainButton != null) playAgainButton.onClick.AddListener(PlayAgain);
    }

    void Update()
    {
        if (resultText != null)
        {
            resultText.text  = didWin ? "YOU WIN!" : "GAME OVER";
            resultText.color = didWin ? Color.green : Color.red;
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore;
        }

        if (highScoreText != null)
        {
            if (finalScore >= highScore && finalScore > 0)
            {
                highScoreText.text  = "NEW High Score: " + highScore + "!";
                highScoreText.color = Color.yellow;
            }
            else
            {
                highScoreText.text  = "High Score: " + highScore;
                highScoreText.color = Color.white;
            }
        }

        if (difficultyText != null)
        {
            difficultyText.text = "Difficulty: " + difficultyName;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}