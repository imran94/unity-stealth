using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float smooth = 1.5f;

    private Transform player;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;

    }

}
