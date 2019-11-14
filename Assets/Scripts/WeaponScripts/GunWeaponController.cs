﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_Shot;
    public GameObject fx_BulletFall;
    private Collider2D fireCollider;
    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_ColliderWait = new WaitForSeconds(0.02f);



    void Start()
    {
        if (!GamePlayController.instance.bullet_And_bulletFX_Created) {
            GamePlayController.instance.bullet_And_bulletFX_Created = true;
            if (nameWp != NameWeapon.FIRE && nameWp != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bulletPrefab, fx_BulletFall, 100);
            }
        }
        if (!GamePlayController.instance.rocket_Bullet_Created)
        {
            if (nameWp == NameWeapon.ROCKET)
            {
                GamePlayController.instance.rocket_Bullet_Created = true;
                SmartPool.instance.CreateRocket(bulletPrefab, 100);
            }
        }

    }

    public override void ProcessAttack()
    {
        //base.ProcessAttack();
        switch (nameWp)
        {
            case NameWeapon.PISTOL:
                break;
            case NameWeapon.MP5:
                break;
            case NameWeapon.M3:
                break;
            case NameWeapon.AWP:
                break;
            case NameWeapon.AK:
                break;
            case NameWeapon.FIRE:
                break;
            case NameWeapon.ROCKET:
                break;
           

        }
        if ((transform != null)&&(nameWp != NameWeapon.FIRE))
        {
            if(nameWp != NameWeapon.ROCKET)
            {
                GameObject bullet_Fall_FX = SmartPool.instance.SpawnBulletFallFX(spawnPoint.transform.position, Quaternion.identity);
                bullet_Fall_FX.transform.localScale = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1f, 1f,1f):new Vector3(1f,1f,1f) ;

                StartCoroutine(WaitForShootEffect());
            }
            SmartPool.instance.SpawnBullet(spawnPoint.transform.position, new Vector3(-transform.root.localScale.x, 0f, 0f), spawnPoint.rotation, nameWp);
        }
        else
        {
            StartCoroutine(ActiveFireCollider());
        }
        

        
    }

    IEnumerator WaitForShootEffect()
    {
        yield return wait_Time;
        fx_Shot.Play();


    }

    IEnumerator ActiveFireCollider()
    {
        //fireCollider.enabled = true;
        fx_Shot.Play();
        yield return fire_ColliderWait;
        //fireCollider.enabled = false;
    }








}

