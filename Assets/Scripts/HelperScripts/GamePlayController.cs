﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}
public enum GameGoal
{
    KILL_ZOMBIES,
    WALK_TO_GOAL_STEPS,
    DEFEND_FENCE,
    TIMER_COUNTDOWN,
    GAME_OVER

}
public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [HideInInspector]
    public bool bullet_And_bulletFX_Created, rocket_Bullet_Created;
    [HideInInspector]
    public bool playerAlive, fenceDestroyed;
    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;
    public GameGoal gameGoal = GameGoal.DEFEND_FENCE;

    public int zombie_Count=20;
    public int timer_Count = 100;

    private Transform playerTarget;

    private Vector3 player_Previous_Position;

    public int step_Count = 100;
    private int initial_Step_Count;

    private Text zombieCounter_Text, timer_Text, stepCounter_Text;
    private Image playerLife;

    [HideInInspector]
    public int coinCount;

    public GameObject pausePanel, gameOverPanel;
    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        playerAlive = true;

        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
            player_Previous_Position = playerTarget.position;

            initial_Step_Count = step_Count;
            stepCounter_Text = GameObject.Find("StepCounter").GetComponent<Text>();
            stepCounter_Text.text = step_Count.ToString();
        }
        if (gameGoal == GameGoal.TIMER_COUNTDOWN || gameGoal == GameGoal.DEFEND_FENCE)
        {
          timer_Text  = GameObject.Find("TimerCounter").GetComponent<Text>();
            timer_Text.text = timer_Count.ToString();
            InvokeRepeating("TimerCountdown",0f,1f);
        }
        if (gameGoal == GameGoal.KILL_ZOMBIES)
        {
            zombieCounter_Text = GameObject.Find("ZombieCounter").GetComponent<Text>();
            zombieCounter_Text.text = zombie_Count.ToString();
        }
        playerLife = GameObject.Find("LifeFull").GetComponent<Image>();

    }
    void OnDisable()
    {
        instance = null;
    }
    void Update()
    {
        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            CountPlayerMovement();
        }
    }
    void CountPlayerMovement()
    {
        Vector3 playerCurrentMovement = playerTarget.position;
        float dist = Vector3.Distance(new Vector3(playerCurrentMovement.x, 0f, 0f), new Vector3(player_Previous_Position.x, 0f, 0f));
        if (playerCurrentMovement.x > player_Previous_Position.x)
        {
            if (dist > 1)
            {

                step_Count--;
                if (step_Count <= 0)
                {
                    print("bleugh");
                }
                player_Previous_Position = playerTarget.position;
            }
        }
        else if (playerCurrentMovement.x < player_Previous_Position.x)
        {
            if (dist > 0.8f)
            {
                step_Count++;
                if (step_Count >= initial_Step_Count)
                {
                    step_Count = initial_Step_Count;
                }
                player_Previous_Position = playerTarget.position;
            }
        }
        
        stepCounter_Text.text = step_Count.ToString();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void TimerCountdown()
    {
        timer_Count--;
        timer_Text.text = timer_Count.ToString();
        if (timer_Count <= 0)
        {
            print("Game Over!");
            CancelInvoke("TimerCountdown");
        }
    }
    public void ZombieDied()
    {
        zombie_Count--;
        zombieCounter_Text.text = zombie_Count.ToString();
        if (zombie_Count <= 0)
        {
            print("Game Over!");
            
        }

    }
    public void PlayerLifeCounter(float fillPercentage)
    {
        fillPercentage /= 100f;
        playerLife.fillAmount = fillPercentage;
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.00001f;
    }
    public void ResumeGame()
    {
        
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }









    }
