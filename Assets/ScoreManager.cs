using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// score text displayed to user
    /// </summary>
    private TMP_Text scoreText;
    /// <summary>
    /// numerical score value
    /// </summary>
    private int score;

    private void Start()
    {
        score = 0;
        scoreText = GetComponentInChildren<TMP_Text>();
        //Debug.Log(scoreText.text);
        //scoreText.text = "Score: 0";
    }

    /// <summary>
    /// Function decreases score
    /// Should be called only when garbage is placed in the wrong bin
    /// </summary>
    public void scoreDecrement()
    {
        if(score <= 2) { 
            score = 0;
            scoreText.text = "Score: 0";
        }
        else {
            score -= 2;
            scoreText.text = "Score: " + score.ToString();
        }
    }
    /// <summary>
    /// Function increases score
    /// Should be called only when garbage is placed in the correct bin
    /// </summary>
    public void scoreIncrement()
    {
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }
}
