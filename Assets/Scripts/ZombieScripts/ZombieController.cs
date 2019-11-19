using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    private ZombieMovement zombie_Movement;
    private ZombieAnimation zombie_Animation;

    private Transform targetTransform;
    private bool canAttack;
    private bool zombie_Alive;


    public GameObject damage_Collider;

    public int zombiehealth = 10;
    public GameObject[] fxDead;
    private float timerAttack;
    private int fireDamage = 10;
    public GameObject coinCollectable;


    void Start()
    {
        zombie_Movement = GetComponent<ZombieMovement>();
        zombie_Animation = GetComponent<ZombieAnimation>();
      
        zombie_Alive = true;



        targetTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }




    void Update()
    {
        if (zombie_Alive)
        {
            CheckDistance();
        }
    }


    void CheckDistance()
    {
        if (targetTransform)
        {
            if(Vector3.Distance(targetTransform.position, transform.position) > 1.5f)
            {
                zombie_Movement.Move(targetTransform);

            }
            else
            {
                if (canAttack)
                {
                    zombie_Animation.Attack();
                }
            }
        }
    }
    public void ActivateDeadEffect(int index)
    {
        fxDead[index].SetActive(true);
        if (fxDead[index].GetComponent<ParticleSystem>())
        {
            fxDead[index].GetComponent<ParticleSystem>().Play();
        }
    }
    IEnumerator DeactivateZombie()
    {
        yield return new WaitForSeconds(2f);

        //Instantiate(coinCollectable, transform.position, Quaternion.identity);

        gameObject.SetActive(false);

    }
    public void DealDamage(int damage)
    {
        zombie_Animation.Hurt();
        zombiehealth -= damage;
        if (zombiehealth <= 0)
        {
            zombie_Alive = false;
            zombie_Animation.Dead();
            StartCoroutine(DeactivateZombie());
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.PLAYER_HEALTH_TAG||target.tag==TagManager.FENCE_TAG)
        {
            canAttack = true;

        }
        if(target.tag==TagManager.BULLET_TAG|| target.tag == TagManager.ROCKET_MISSILE_TAG)
        {
            zombie_Animation.Hurt();
            zombiehealth -= target.gameObject.GetComponent<BulletController>().damage;
            if (target.tag == TagManager.ROCKET_MISSILE_TAG)
            {
                target.gameObject.GetComponent<BulletController>().ExplosionFX();
            }
            if (zombiehealth <= 0)
            {
                zombie_Alive = false;
                zombie_Animation.Dead();
                StartCoroutine(DeactivateZombie());
            }
            target.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.PLAYER_HEALTH_TAG || target.tag == TagManager.FENCE_TAG)
        {
            canAttack = false;

        }
    }







}
