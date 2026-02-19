using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        float width = GameManager.GetBasketWidth();
        Vector3 scale = transform.localScale;
        scale.x = width;
        transform.localScale = scale;

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreText = scoreGO.GetComponent<Text>();
            if (scoreText != null)
            {
                scoreText.text = "0";
                Debug.Log("ScoreCounter found successfully");
            }
        }
        else
        {
            Debug.LogError("ScoreCounter GameObject not found! Make sure it is named exactly 'ScoreCounter'");
        }
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            if (scoreText != null)
            {
                int score = int.Parse(scoreText.text);
                score += 100;
                scoreText.text = score.ToString();

                if (score > HighScore.score)
                {
                    HighScore.score = score;
                    PlayerPrefs.SetInt("HighScore", score);
                }
            }

            else
            {
                Debug.LogError("scoreText is null in OnCollisionEnter!");
            }

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null)
            {
                apScript.AppleCaught();
            }
        }
    }
}