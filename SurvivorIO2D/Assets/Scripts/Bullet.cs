using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        var transform1 = transform;
        var temp = Instantiate(hitEffect, transform1.position, transform1.rotation);
        Destroy(temp, 0.5f);
        Destroy(gameObject);
    }
}
