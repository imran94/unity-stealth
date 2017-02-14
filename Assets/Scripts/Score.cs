using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    public static int score;
    public GameObject item1;
    public GameObject item2;
    private bool item1Check;
    private bool item2Check;
    private bool alarmTriggered;
    private bool alarmCheck;

    private void Start()
    {
        score = 0;
        item1Check = false;
        item2Check = false;
        alarmCheck = false;
        DisplayScore();
    }


    private void Update()
    {
        if (item1 == null && item1Check == false)
        {
            score = score + 5;
            DisplayScore();
            item1Check = true;
        }

        if (item2 == null && item2Check == false)
        {
            score = score + 5;
            DisplayScore();
            item2Check = true;
        }
        alarmTriggered = AlarmLight.alarmStatus;
        if (alarmTriggered == true && alarmCheck == false)
        {
            score -= 10;
            DisplayScore();
            alarmCheck = true;
        }
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
