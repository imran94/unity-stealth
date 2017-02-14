using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

    public int dyingState, locomotionState, shoutState, weaponShootState;
    public int deadBool, enemyDeadBool, sneakingBool, shoutingBool, playerInSightBool, openBool, shootingBool;
    public int speedFloat, shotFloat, aimWeightFloat, angularSpeedFloat;

    void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        shoutState = Animator.StringToHash("Shouting.Shout");
        weaponShootState = Animator.StringToHash("Shooting.WeaponShoot");

        deadBool = Animator.StringToHash("Dead");
        enemyDeadBool = Animator.StringToHash("EnemyDead");
        sneakingBool = Animator.StringToHash("Sneaking");
        shoutingBool = Animator.StringToHash("Shouting");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
        openBool = Animator.StringToHash("Open");
        shootingBool = Animator.StringToHash("PlayerShooting");
        
        speedFloat = Animator.StringToHash("Speed");
        shotFloat = Animator.StringToHash("Shot");
        aimWeightFloat = Animator.StringToHash("AimWeight");
        angularSpeedFloat = Animator.StringToHash("AngularSpeed");
    }
}
