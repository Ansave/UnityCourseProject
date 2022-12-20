using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (pauseMenu.activeSelf) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    
    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
