using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float elapsedSeconds;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        elapsedSeconds = 0;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedSeconds += Time.deltaTime;
            scoreText.text = ("Time: "+(int)(elapsedSeconds)).ToString();
            

        }

        
    }

    public void StopGameTimer()
    {
        isRunning = false;
       
        
    }
}
