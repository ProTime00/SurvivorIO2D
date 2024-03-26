using System;
using System.Collections;
using System.Collections.Generic;
using CandyCoded.HapticFeedback.iOS;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using HapticFeedback = CandyCoded.HapticFeedback.HapticFeedback;

public class LevelManager : MonoBehaviour
{
    public static LevelManager i;
    
    public Text InfoDisplay;
    
    private int _enemyKilled;
    private int _score;
    private int _playerHp = 1000;
    private const float BaseInvincibilityTimer = 0.07f;
    private float _invincibilityTime;


    private void Awake()
    {
        i = this;
        _invincibilityTime = BaseInvincibilityTimer;
    }

    private void Start()
    {
        BaseEnemy.OnEnemyKilled += BaseEnemyOnOnEnemyKilled;
    }

    private void BaseEnemyOnOnEnemyKilled(int score)
    {
        _score += score;
        _enemyKilled++;
        if (_enemyKilled >=  4)
        {
            SceneLoader.LoadMainMenu();
        }
        InfoDisplay.text = $"Score: {_score}\nkills: {_enemyKilled}\nhp: {_playerHp}";
    }

    private void OnDestroy()
    {
        BaseEnemy.OnEnemyKilled -= BaseEnemyOnOnEnemyKilled;
    }


    private void FixedUpdate()
    {
        if (_invincibilityTime > 0)
        {
            _invincibilityTime -= Time.fixedDeltaTime;
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        if (_invincibilityTime > 0)
        {
            return;
        }
        HapticFeedback.LightFeedback();
        _playerHp -= damage;
        InfoDisplay.text = $"Score: {_score}\nkills: {_enemyKilled}\nhp: {_playerHp}";
        _invincibilityTime = BaseInvincibilityTimer;
        if (_playerHp <= 0)
        {
            SceneLoader.LoadMainMenu();
        }
    }
}
