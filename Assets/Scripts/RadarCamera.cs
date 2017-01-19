using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCamera : MonoBehaviour {

    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Transform>();
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        Debug.Log("Update RadarCamera: " + transform.position);
    }
}
