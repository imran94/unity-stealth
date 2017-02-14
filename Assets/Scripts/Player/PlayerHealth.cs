using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip gameOverClip;
    public float health = 100f;
    public float resetAfterDeathTime = 5f;
    private bool dead = false;

    private Animator anim;
    private PlayerMovement playerMovement;
    private HashIDs hash;
    private FadeManager screenFader;

    private LastPlayerSighting lastPlayerSighting;
    private float timer;
    private bool playerDead;
    private AudioSource audioSource;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        screenFader = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<FadeManager>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
    }

    void Update()
    {
        if (health <= 0)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
            else
            {
                PlayerDead();
                LevelReset();
            }
        }
    }

    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, true);
    }

    void PlayerDead()
    {
        // play dying animation only once
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.dyingState)
        {
            anim.SetBool(hash.deadBool, false);
        }

        anim.SetFloat(hash.speedFloat, 0);
        playerMovement.enabled = false;
        lastPlayerSighting.position = lastPlayerSighting.resetPosition;
        audioSource.Stop();
    }

    void LevelReset()
    {
        if (dead) return;

        timer += Time.deltaTime;

        if (timer >= resetAfterDeathTime)
        {
            AudioSource.PlayClipAtPoint(gameOverClip, transform.position);
            screenFader.FadeOut(SceneManager.GetActiveScene().buildIndex);
            dead = true;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
