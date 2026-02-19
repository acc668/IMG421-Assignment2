using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Text difficultyDescriptionText;

    public Button tutorialButton;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button hellButton;

    void Start()
    {
        GameResult.playerWon  = false;
        GameResult.finalScore = 0;

        tutorialButton.onClick.AddListener(SelectTutorial);
        easyButton.onClick.AddListener(SelectEasy);
        mediumButton.onClick.AddListener(SelectMedium);
        hardButton.onClick.AddListener(SelectHard);
        hellButton.onClick.AddListener(SelectHell);

        ShowDescription(GameManager.Difficulty.Easy);
    }

    public void SelectTutorial()
    {
        GameManager.selectedDifficulty = GameManager.Difficulty.Tutorial;
        StartGame();
    }

    public void SelectEasy()
    {
        GameManager.selectedDifficulty = GameManager.Difficulty.Easy;
        StartGame();
    }

    public void SelectMedium()
    {
        GameManager.selectedDifficulty = GameManager.Difficulty.Medium;
        StartGame();
    }

    public void SelectHard()
    {
        GameManager.selectedDifficulty = GameManager.Difficulty.Hard;
        StartGame();
    }

    public void SelectHell()
    {
        GameManager.selectedDifficulty = GameManager.Difficulty.Hell;
        StartGame();
    }

    public void HoverTutorial()  { ShowDescription(GameManager.Difficulty.Tutorial); }
    public void HoverEasy()      { ShowDescription(GameManager.Difficulty.Easy);     }
    public void HoverMedium()    { ShowDescription(GameManager.Difficulty.Medium);   }
    public void HoverHard()      { ShowDescription(GameManager.Difficulty.Hard);     }
    public void HoverHell()      { ShowDescription(GameManager.Difficulty.Hell);     }

    void ShowDescription(GameManager.Difficulty d)
    {
        if (difficultyDescriptionText == null) return;

        switch (d)
        {
            case GameManager.Difficulty.Tutorial:
                difficultyDescriptionText.text =
                    "TUTORIAL\nLearn the ropes! Slow apples, wide baskets, 5 lives.\nCatch 5 apples to win.";
                break;
            case GameManager.Difficulty.Easy:
                difficultyDescriptionText.text =
                    "EASY\nA relaxed pace. Normal apples, 3 baskets.\nCatch 20 apples to win.";
                break;
            case GameManager.Difficulty.Medium:
                difficultyDescriptionText.text =
                    "MEDIUM\nThings pick up. Faster tree, tighter baskets.\nCatch 35 apples to win.";
                break;
            case GameManager.Difficulty.Hard:
                difficultyDescriptionText.text =
                    "HARD\nFast tree, narrow baskets, only 2 lives.\nCatch 50 apples to win.";
                break;
            case GameManager.Difficulty.Hell:
                difficultyDescriptionText.text =
                    "HELL\nTWO trees. One basket. Good luck.\nCatch 75 apples to survive.";
                break;
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}