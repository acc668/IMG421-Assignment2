using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public GameObject appleTreePrefab;
    public float basketBottomY  = -14f;
    public float basketSpacingY = 2f;

    [Header("Set Dynamically")]
    public List<GameObject> basketList;

    private int caughtCount = 0;
    private int winTarget   = 20;

    private bool gameOver = false;

    private Text progressText;

    void Start()
    {
        winTarget = GameManager.GetWinTarget();

        if (GameManager.selectedDifficulty == GameManager.Difficulty.Tutorial)
        {
            GameObject tutGO = GameObject.Find("TutorialManager");
            if (tutGO != null)
            {
                tutGO.SetActive(true);
                TutorialManager tutScript = tutGO.GetComponent<TutorialManager>();
                if (tutScript != null)
                {
                    tutScript.StartTutorial();
                }
                else
                {
                    Debug.LogError("TutorialManager script not found on TutorialManager GameObject!");
                }
            }
            else
            {
                Debug.LogError("TutorialManager GameObject not found in scene!");
            }
        }

        basketList = new List<GameObject>();
        int numBaskets = GameManager.GetNumBaskets();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        if (GameManager.UsesTwoTrees())
        {
            GameObject secondTree = Instantiate<GameObject>(appleTreePrefab);
            secondTree.transform.position = new Vector3(-10f, 12f, 0f);
            AppleTree treeScript = secondTree.GetComponent<AppleTree>();
            if (treeScript != null)
            {
                treeScript.isSecondTree = true;
            }
        }

        GameObject progressGO = GameObject.Find("ProgressCounter");
        if (progressGO != null)
        {
            progressText = progressGO.GetComponent<Text>();
        }
        UpdateProgressUI();
    }

    public void AppleDestroyed()
    {
        if (gameOver) return;
        Debug.Log("Apple missed! Baskets remaining: " + (basketList.Count - 1));

        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            TriggerGameOver(false);
        }
    }

    public void AppleCaught()
    {
        if (gameOver) return;
        caughtCount++;
        Debug.Log("Apple caught! Count: " + caughtCount + " / " + winTarget);
        UpdateProgressUI();

        if (caughtCount >= winTarget)
        {
            TriggerGameOver(true);
        }
    }

    void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = "Caught: " + caughtCount + " / " + winTarget;
        }
    }

    void TriggerGameOver(bool didWin)
    {
        gameOver = true;

        GameResult.playerWon  = didWin;
        GameResult.finalScore = caughtCount * 100;

        Debug.Log("TriggerGameOver called — won: " + didWin + " score: " + GameResult.finalScore);

        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("GameOver");
    }
}