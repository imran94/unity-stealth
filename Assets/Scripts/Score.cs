using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    private int score;
    public GameObject item1;
    private bool item1Check;

    private void Start()
    {
        score = 0;
        item1Check = false;
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
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
