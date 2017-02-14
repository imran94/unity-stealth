using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;

    private EnemyAI enemyAI;
    private EnemySight enemySight;
    private EnemyShooting enemyShooting;

    private Animator anim;
    private HashIDs hash;
    private bool enemyDead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        enemyDead = false;

        enemyAI = GetComponent<EnemyAI>();
        enemySight = GetComponent<EnemySight>();
        enemyShooting = GetComponent<EnemyShooting>();
    }

    void Update()
    {
		if (health <= 0)
        {
            if (!enemyDead)
            {
                EnemyDying();
            }
            else
            {
                EnemyDead();
            }

        }
	}

    private void EnemyDying()
    {
        enemyDead = true;
        anim.SetBool(hash.enemyDeadBool, true);
    }

    private void EnemyDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.dyingState)
        {
            anim.SetBool(hash.enemyDeadBool, false);
        }

        anim.SetFloat(hash.speedFloat, 0);
        DisableScripts();
    }

    private void DisableScripts()
    {
        enemySight.enabled = false;
        enemyAI.enabled = false;
        enemyShooting.enabled = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
