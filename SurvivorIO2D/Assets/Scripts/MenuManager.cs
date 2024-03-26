using System;
using System.Collections;
using System.Collections.Generic;
using CandyCoded.HapticFeedback;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text levelReached;

    private void Start()
    {
        levelReached.text = $"You reached the level {GameManager.i.levelReached}. Try to beat it!";
    }

    public void LoadNextLevel()
    {
        HapticFeedback.LightFeedback();
        SceneLoader.LoadLevel(GameManager.i.levelReached);
    }
}
