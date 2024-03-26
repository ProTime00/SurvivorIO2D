using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class BaseEnemy : MonoBehaviour
{
    public int maxHp;
    public int baseSpeed;
    public Object hitEffect;

    private int _hp;
    private const int Score = 200;
    private GameObject _player;
    private Rigidbody2D _rb;
    private Vector3 dir;

    public delegate void EnemyKilled(int score);

    public static event EnemyKilled OnEnemyKilled;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hp = maxHp;
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        dir = _player.transform.position - transform.position;
        _rb.velocity = Vector2.zero;
        transform.Translate(dir.normalized * (baseSpeed * Time.deltaTime), Space.World);
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        _rb.rotation = angle;
    }

    public bool TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            OnEnemyKilled?.Invoke(Score);
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.i.PlayerTakeDamage(10);
        }
    }
}
