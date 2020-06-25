using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text scoreUI;
    private float scoreTimer = 1.5f;
    private float currentTime;

    void Start() 
    {
        currentTime = scoreTimer;
        score = 0;
        scoreUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= scoreTimer){
            score++;
            scoreUI.text = score.ToString();
            currentTime = 0f;
        }
    }
}
