using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHighScore : MonoBehaviour
{
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text highScoreText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject gameOverCanvas;
    [SerializeField]
    GameObject hud1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ship = GameObject.FindGameObjectsWithTag("Player").Length;
        
        if (ship == 0)
        {
            gameOverText.text = "Your Score: " + scoreText.text + "    " + highScoreText.text ;
            gameOverCanvas.SetActive(true);
            hud1.SetActive(false);


        }
    }
}
