﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(GamePlayController.instance.gameGoal !=GameGoal.DEFEND_FENCE && GamePlayController.instance.gameGoal != GameGoal.GAME_OVER)
        {
            if (playerTransform)
            {
                Vector3 temp = transform.position;
                temp.x = playerTransform.position.x;
                transform.position = temp;

            }
        }
    }
}
