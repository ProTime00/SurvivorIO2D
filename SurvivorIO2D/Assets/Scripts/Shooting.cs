using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;

    private const float DefaultShootTimer = 1.5f;
    private float _shootTimer;

    private void Awake()
    {
        _shootTimer = DefaultShootTimer;
    }

    
    void Update()
    {
        if (_shootTimer <= 0)
        {
            _shootTimer = DefaultShootTimer;
            Shoot();
        }

        _shootTimer -= Time.deltaTime;
        
    }

    private void Shoot()
    {
        var transform1 = transform;
        var bullet = Instantiate(bulletPrefab, transform1.position, transform1.rotation);
        var rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.rotation += 90;
        rbBullet.AddForce(transform1.up * bulletForce, ForceMode2D.Impulse);
        
    }
}
