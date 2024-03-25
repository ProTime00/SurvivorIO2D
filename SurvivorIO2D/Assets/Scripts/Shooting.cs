using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;

    private float shootTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (shootTimer <= 0)
        {
            shootTimer = 0.5f;
            Shoot();
        }

        shootTimer -= Time.deltaTime;
        
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
