using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public GameObject levelCompleteMenu;

    private void Start()
    {
        GlobalEventManager.OnLevelComplete.AddListener(() => levelCompleteMenu.SetActive(true));
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
