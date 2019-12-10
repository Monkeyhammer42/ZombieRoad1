using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [HideInInspector]
    public bool bullet_And_bulletFX_Created, rocket_Bullet_Created;
    [HideInInspector]
    public bool playerAlive;
    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        playerAlive = true;
    }
    void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }









}
