using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour {
    public GameObject menu;
    private GameObject player;

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
            Debug.Log("Player entered");
            menu.SetActive(true);
            //Time.timeScale = 0;
        }
    }
}
