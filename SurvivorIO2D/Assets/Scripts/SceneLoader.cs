using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader i;
    private void Awake()
    {
        if (i is not null)
        {
            Destroy(gameObject);
        }

        i = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
