using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject pickup;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetButton("Switch"))
            {
                RemoveObject();
            }
        }
    }

    void RemoveObject()
    {
        pickup.SetActive(false);
        Debug.Log("Item Picked Up");
        Destroy(pickup);
        //update score
    }
}
