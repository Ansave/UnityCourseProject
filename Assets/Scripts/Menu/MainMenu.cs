using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void StartNewGame()
    {
        levelLoader.gameObject.SetActive(true);
        levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ExitGame()
    {
        Debug.Log("Game is closed");
        Application.Quit();
    }
}
