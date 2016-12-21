using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour {
    public GameObject laser;
    public Material unlockedMat;
    private GameObject player;
    private Renderer screenRend;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetButton ("Switch"))
            {

            }
        }
    }

    void LaserDeactivation()
    {
        laser.SetActive(false);

        screenRend = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();
        screenRend.material = unlockedMat;
        GetComponent<AudioSource>().Play();

    }
}
