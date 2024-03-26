using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    
    public int levelReached = 1;
    

    private void Awake()
    {
        if (i is not null)
        {
            Destroy(gameObject);
        }

        i = this;
        DontDestroyOnLoad(gameObject);
    }
}
