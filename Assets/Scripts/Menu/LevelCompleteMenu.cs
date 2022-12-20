using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteMenu;

    private void Start()
    {
        GlobalEventManager.OnLevelComplete.AddListener(() => levelCompleteMenu.SetActive(true));
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
