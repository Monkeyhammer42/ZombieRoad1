using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
