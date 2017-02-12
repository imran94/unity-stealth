using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    private int score;
    public GameObject item1;
    public GameObject item2;
    private bool item1Check;
    private bool item2Check;

    private void Start()
    {
        score = 0;
        item1Check = false;
        item2Check = false;
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
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
