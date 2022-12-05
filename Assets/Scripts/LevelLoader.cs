using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public Slider progressBar;

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(AsyncLoadLevel(levelIndex));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator AsyncLoadLevel(int levelIndex)
    {
        AsyncOperation levelLoading = SceneManager.LoadSceneAsync(levelIndex);

        while (!levelLoading.isDone) {
            progressBar.value = levelLoading.progress;
            yield return null;
        }
    }
}
