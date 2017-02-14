using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    public Text item1Text;
    public Text item2Text;
    public Text laser1Text;
    public Text laser2Text;
    public Text laser3Text;
    public Text laser4Text;
    public Text alarmText;
    public static int score;
    public GameObject item1;
    public GameObject item2;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    private bool item1Check;
    private bool item2Check;
    private bool alarmTriggered;
    private bool alarmCheck;
    private bool laser1Check;
    private bool laser2Check;
    private bool laser3Check;
    private bool laser4Check;


    private void Start()
    {
        score = 0;
        item1Check = false;
        item2Check = false;
        alarmCheck = false;
        laser1Check = false;
        DisplayScore();
    }


    private void Update()
    {
        if (item1 == null && item1Check == false)
        {
            score = score + 5;
            DisplayScore();
            item1Check = true;
            item1Text.text = "Item 1 --> +5";
        }

        if (item2 == null && item2Check == false)
        {
            score = score + 5;
            DisplayScore();
            item2Check = true;
            item2Text.text = "Item 2 --> +5";
        }
        alarmTriggered = AlarmLight.alarmStatus;
        if (alarmTriggered == true && alarmCheck == false)
        {
            score -= 10;
            DisplayScore();
            alarmCheck = true;
            alarmText.text = "Alarm Triggered --> -10";
        }
        if (laser1.activeInHierarchy == false && laser1Check == false)
        {
            score += 5;
            DisplayScore();
            laser1Check = true;
            laser1Text.text = "Laser 1 --> +5";
        }
        if (laser2.activeInHierarchy == false && laser2Check == false)
        {
            score += 5;
            DisplayScore();
            laser2Check = true;
            laser2Text.text = "Laser 2 --> +5";
        }
        if (laser3 != null)
        {
            if (laser3.activeInHierarchy == false && laser3Check == false)
            {
                score += 5;
                DisplayScore();
                laser3Check = true;
                laser3Text.text = "Laser 3 --> +5";
            }
        }
        if (laser4 != null)
        {
            if (laser4.activeInHierarchy == false && laser4Check == false)
            {
                score += 5;
                DisplayScore();
                laser4Check = true;
                laser4Text.text = "Laser 4 --> +5";
            }
        }
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
