﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject[] blood_FX;
    private PlayerAnimations playerAnim;

   
    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
    }




    public void DealDamage(int damage)
    {
        health -= damage;
        playerAnim.Hurt();
        if (health <= 0)
        {
            
            GamePlayController.instance.playerAlive = false;
            GetComponent<Collider2D>().enabled = false;
            playerAnim.Dead();
            blood_FX[Random.Range(0, blood_FX.Length)].SetActive(true);
        }
    }




}
