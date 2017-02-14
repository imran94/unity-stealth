using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destination : MonoBehaviour {

    private GameObject player;
    public GameObject canvas;
    public Text scoreText;
    private int score;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    // Update is called once per frame
    void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //SceneManager.LoadScene(0);
            canvas.SetActive(true);
            Time.timeScale = 0;
            score = Score.score;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
