using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public AudioSource coinPickup;

    private void Start()
    {
        coinPickup = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D target)
    {

        if(target.tag==TagManager.PLAYER_TAG|| target.tag == TagManager.PLAYER_HEALTH_TAG)
        {
            Debug.Log("HELP");
            GamePlayController.instance.coinCount++;
            coinPickup.Play();
            StartCoroutine(DeactivateCoin());
           

        }
    }
    IEnumerator DeactivateCoin()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }
}
