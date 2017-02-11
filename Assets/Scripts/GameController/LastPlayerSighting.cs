﻿using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour {

    // default value for meaning player is out of sight
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);
    public float lightHighIntensity = 0.25f;
    public float lightLowIntensity = 0f;
    public float fadeSpeed = 7f;
    public float musicFadeSpeed = 1f;

    private AlarmLight alarm;
    private Light mainLight;

    private AudioSource normalAudio;
    private AudioSource panicAudio;
    private AudioSource[] sirens;

    void Awake()
    {
        alarm = GameObject.FindGameObjectWithTag(Tags.alarm).GetComponent<AlarmLight>();
        mainLight = GameObject.FindGameObjectWithTag(Tags.mainLight).GetComponent<Light>();
        normalAudio = gameObject.GetComponent<AudioSource>();
        panicAudio = transform.FindChild("SecondaryMusic").GetComponent<AudioSource>();

        GameObject[] sirenGameObjects = GameObject.FindGameObjectsWithTag(Tags.siren);
        sirens = new AudioSource[sirenGameObjects.Length];

        for (int i = 0; i < sirens.Length; i++)
        {
            sirens[i] = sirenGameObjects[i].GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        SwitchAlarms();
        MusicFade();
    }

    void SwitchAlarms()
    {
        // Turn alarms on if player is seen
        alarm.alarmOn = (position != resetPosition);

        float newIntensity;

        if (position != resetPosition)
        {
            newIntensity = lightLowIntensity;
        }
        else
        {
            newIntensity = lightHighIntensity;
        }

        mainLight.intensity = Mathf.Lerp(mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);
        
        for (int i = 0; i < sirens.Length; i++)
        {
            if (position != resetPosition && !sirens[i].isPlaying)
            {
                sirens[i].Play();
            }
            else if (position == resetPosition)
            {
                sirens[i].Stop();
            }
        }
    }

    void MusicFade()
    {
        // player is spotted
        if (position != resetPosition)
        {
            normalAudio.volume = Mathf.Lerp(normalAudio.volume, 0f, musicFadeSpeed * Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
        }
        else
        {
            normalAudio.volume = Mathf.Lerp(normalAudio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, 0f, musicFadeSpeed * Time.deltaTime);
        }
    }

    public void ResetPosition()
    {
        position = resetPosition;
    }
}
