using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour {

    private GameObject player;
    private FadeManager screenFader;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        screenFader = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<FadeManager>();
    }

    void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            screenFader.FadeOut(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
