using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    
    private void Start()
    {
        GlobalEventManager.OnPlayerKilled.AddListener(() => gameOverMenu.SetActive(true));
    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
