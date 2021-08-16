using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameManager.GetScore().ToString();
    }
}
