using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    
    private void Start()
    {
        GlobalEventManager.OnPlayerKilled.AddListener(() => gameOverMenu.SetActive(true));
    }
    
    private void ReloadLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }
    
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
