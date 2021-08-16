using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadBossScene()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<GameManager>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
