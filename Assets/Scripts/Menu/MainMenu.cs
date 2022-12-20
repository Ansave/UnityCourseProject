using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    private void StartNewGame()
    {
        levelLoader.gameObject.SetActive(true);
        levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void ExitGame()
    {
        Debug.Log("Game is closed");
        Application.Quit();
    }
}
