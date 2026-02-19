using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject promptPanel;
    public Text promptText;
    public float promptDuration = 4f;

    private string[] prompts = new string[]
    {
        "Welcome to Apple Picker!\nUse your MOUSE to move the basket.",
        "Move left and right to position yourself\nunder the falling apples.",
        "The tree at the top drops apples.\nCatch them before they hit the ground!",
        "If an apple hits the ground, you lose a basket.\nYou have 5 baskets — use them wisely.",
        "Catch 5 apples to WIN this tutorial.\nGood luck — let's go!"
    };

    void Start()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }
    }

    public void StartTutorial()
    {
        Debug.Log("StartTutorial called successfully");

        if (promptPanel == null)
        {
            Debug.LogError("promptPanel is null!");
            return;
        }

        if (promptText == null)
        {
            Debug.LogError("promptText is null!");
            return;
        }

        StartCoroutine(RunTutorialPrompts());
    }

    IEnumerator RunTutorialPrompts()
    {
        foreach (string prompt in prompts)
        {
            promptPanel.SetActive(true);
            promptText.text = prompt;
            Debug.Log("Showing prompt: " + prompt);
            yield return new WaitForSeconds(promptDuration);
        }

        promptPanel.SetActive(false);
    }
}