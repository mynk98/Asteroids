using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimeAttack : MonoBehaviour
{
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject gameOverCanvas;
    [SerializeField]
    GameObject hud;
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
            string time = scoreText.text.Substring(6);
            if (time=="1" || time== "0")
            {
                gameOverText.text = "You survived for: " + time+ " second";

            }
            else
            {
                gameOverText.text = "You survived for: " + time +" seconds";
            }
            gameOverCanvas.SetActive(true);
            hud.SetActive(false);
            
        }
        int asteroids = GameObject.FindGameObjectsWithTag("asteroid").Length;
        if (asteroids == 0)
        {
            string time = scoreText.text.Substring(6);
            gameOverText.text = "Congratulations, you completed in " + time + " seconds";
            gameOverCanvas.SetActive(true);
            hud.SetActive(false);
            HUD script = hud.GetComponent<HUD>();
            script.StopGameTimer();

        }
    }
}
