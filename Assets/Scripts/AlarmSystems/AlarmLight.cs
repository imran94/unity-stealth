using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

    
    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;

    private Light redLight;
    private float targetIntensity;

    void Awake()
    {
        redLight = GetComponent<Light>();

        redLight.intensity = 0f;
        targetIntensity = highIntensity;
    }

    void Update()
    {
        if (alarmOn)
        {
            redLight.intensity = Mathf.Lerp(redLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            checkTargetIntensity();
        }
        else
        {
            redLight.intensity = Mathf.Lerp(redLight.intensity, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void checkTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity - redLight.intensity) < changeMargin)
        {
            targetIntensity = (targetIntensity == highIntensity) ? lowIntensity : highIntensity;
            Debug.Log("TargetIntensity: " + targetIntensity);
        }
    }
}
