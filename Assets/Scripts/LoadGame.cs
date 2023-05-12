using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [Header("Menus")]
    public GameObject loadingScreen;
    public GameObject MainMenu;

    [Header("Slider")]
    public Slider loadingSlider;

    public void LoadScene(string EvergladeCity)
    {
        MainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadIntoGame(EvergladeCity));
    }
    IEnumerator LoadIntoGame(string EvergladeCity)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(EvergladeCity);
        AudioListener.pause = false;

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
