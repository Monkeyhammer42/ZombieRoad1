using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFX : MonoBehaviour
{






    void OnEnable()
    {
        Invoke("DeactivateGameObject", 2f);
    }
    

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }










}
