using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public AudioClip shotClip;

    public float maxDamage = 120f;
    public float minDamage = 45f;

    public float flashIntensity = 1f;
    public float fadeSpeed = 10f;

    private Animator anim;
    private HashIDs hash;
    private LineRenderer laserShotLine;
    private Light laserShotLight;

    private bool shooting;
    private int hashShootingBool;
    private float scaledDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = laserShotLine.gameObject.GetComponent<Light>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        laserShotLine.enabled = false;
        laserShotLight.intensity = 0f;

        scaledDamage = maxDamage - minDamage;
    }
	
	void Update ()
    {
        float shot = anim.GetFloat(hash.shotFloat);

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && !shooting)
        {
            Shoot();
        }

        if (shot < 0.5f)
        {
            //shooting = false;
            laserShotLine.enabled = false;
        }

        laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // Gets hash number of current state in the shooting layer
        int hashState = anim.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash;
        if (hashState == hash.weaponShootState && shooting)
        {
            ShotEffects();
            shooting = false;
            anim.SetBool(hash.shootingBool, shooting);
        }

        //float aimWeight = anim.GetFloat(hash.aimWeightFloat);
        //anim.SetIKPosition(AvatarIKGoal.RightHand, transform.up * 1.5f);
        //anim.SetIKPositionWeight(AvatarIKGoal.RightHand, aimWeight);
    }

    void Shoot()
    {
        shooting = true;
        anim.SetBool(hash.shootingBool, shooting);
    }

    void ShotEffects()
    {
        //laserShotLine.SetPosition(0, laserShotLine.transform.position);
        //laserShotLine.SetPosition(1, transform.forward + Vector3.up * 1.5f);
        laserShotLine.enabled = true;
        laserShotLight.intensity = flashIntensity;
        AudioSource.PlayClipAtPoint(shotClip, laserShotLight.transform.position);
    }
}
