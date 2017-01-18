using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

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
        }
    }
}
