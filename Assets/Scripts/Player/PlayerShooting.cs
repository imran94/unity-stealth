using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public AudioClip shotClip;

    public float maxDamage = 120f;
    public float minDamage = 45f;
    public float range = 100f;

    public float flashIntensity = 1f;
    public float fadeSpeed = 10f;

    private GameObject playerGun;

    private Animator anim;
    private HashIDs hash;
    private LineRenderer laserShotLine;
    private Light laserShotLight;
    //private SphereCollider sphereCol;

    private bool shooting;
    private float scaledDamage;

    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //sphereCol = GetComponent<SphereCollider>();

        playerGun = GameObject.FindGameObjectWithTag(Tags.playerGun);

        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = laserShotLine.gameObject.GetComponent<Light>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        laserShotLine.enabled = false;
        laserShotLight.intensity = 0f;

        scaledDamage = maxDamage - minDamage;

        shootableMask = LayerMask.GetMask("Shootable");
        playerGun.SetActive(false);
    }

    void Update()
    {
        float shot = anim.GetFloat(hash.shotFloat);

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && !shooting && playerGun.activeSelf)
        {
            shooting = true;
            anim.SetBool(hash.shootingBool, shooting);
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

        // Player is in shooting animation
        if (hashState == hash.weaponShootState && shooting)
        {
            Shoot();
            shooting = false;
            anim.SetBool(hash.shootingBool, shooting);
        }

        //float aimWeight = anim.GetFloat(hash.aimWeightFloat);
        //anim.SetIKPosition(AvatarIKGoal.RightHand, transform.up * 1.5f);
        //anim.SetIKPositionWeight(AvatarIKGoal.RightHand, aimWeight);
    }

    void Shoot()
    {
        ShotEffects();

        shootRay.origin = transform.position + Vector3.up;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask) /*&& shootHit.collider.tag == "Enemy"*/)
        {
            //EnemyHealth e = shootHit.collider.GetComponent<EnemyHealth>();
            shootHit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(maxDamage);
        }
    }

    void ShotEffects()
    {
        //laserShotLine.SetPosition(0, laserShotLine.transform.position);
        //laserShotLine.SetPosition(1, transform.forward + Vector3.up * 1.5f);
        laserShotLine.enabled = true;
        laserShotLight.intensity = flashIntensity;
        AudioSource.PlayClipAtPoint(shotClip, laserShotLight.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.gunPickup)
        {
            Debug.Log("OnTriggerEnter");
            other.gameObject.SetActive(false);
            playerGun.SetActive(true);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.ta == player)
    //    {
    //    }
    //}
}
