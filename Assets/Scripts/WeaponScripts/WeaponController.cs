using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET

}
public class WeaponController : MonoBehaviour
{

    public DefaultConfig defaultConfig;
    public NameWeapon nameWp;


    protected PlayerAnimations playerAnim;
    protected float lastShot;

    public int gunIndex;
    public int currentBullet;
    public int bulletMaximum;



    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMaximum;

    }

    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();
                playerAnim.AttackAnimation();
                lastShot = Time.time;
                currentBullet--;
            }
            else
            {

            }
        }
    }

    public virtual void ProcessAttack() {}






















}
