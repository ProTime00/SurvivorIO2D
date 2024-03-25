using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    public bool followOnX;
    public bool folloxOnY;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        var pos = transform.position;
        var position = player.transform.position;
        pos.x = position.x;
        pos.y = position.y + 10;
        if (!followOnX)
        {
            pos.x = 0;
        }

        if (!folloxOnY)
        {
            pos.y = 10;
        }
        transform.position = pos;
    }
}
