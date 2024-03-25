using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Joystick joystick;
    
    [Header("Stats of the player")]
    public float moveSpeed = 5;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = joystick.Direction;

        if (joystick.Direction == Vector2.zero) return;
        _direction = joystick.Direction;
    }

    private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));

            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90;
            _rb.rotation = angle;
        }
}
