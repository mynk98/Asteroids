using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD1 : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text highScoreText;
    int score;
    int highScore;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        //print(score);
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = "High Score: " + highScore;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        //print(scoreText.text);
    }

    



}
