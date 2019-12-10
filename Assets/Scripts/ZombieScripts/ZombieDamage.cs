using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1;
    public int damage = 3;
  





    void Update()
    {
        if (GamePlayController.instance.zombieGoal == ZombieGoal.PLAYER)
        {
            AttackPlayer();
        }
        if (GamePlayController.instance.zombieGoal == ZombieGoal.FENCE)
        {
            AttackFence();
        }
        
    }
    void AttackPlayer()
    {
        if (GamePlayController.instance.playerAlive)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);
            if (target.tag == TagManager.PLAYER_HEALTH_TAG)
            {
                target.GetComponent<PlayerHealth>().DealDamage(damage);
            }
        }
    }
    void AttackFence()
    {
        if (!GamePlayController.instance.fenceDestroyed)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);
            if (target.tag == TagManager.FENCE_TAG)
            {
                target.GetComponent<FenceHealth>().DealDamage(damage);
            }
        }
    }

















}
