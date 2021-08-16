using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    /*
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void Update()
    {
        if (score == 10000)
        {
            score += 100;
            level.LoadBossScene();
        }
        if (score == 10600)
        {
            score += 100;
            level.LoadSceneOne();
        }
    }
    */

    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int gameManagerSessions = FindObjectsOfType<GameManager>().Length;

        if (gameManagerSessions > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
