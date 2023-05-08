using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuseumPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public AudioSource Menu;
    public AudioSource Back;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Menu.ignoreListenerPause = true;
        Back.ignoreListenerPause = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("FrontEnd");
        AudioListener.pause = true;
    }
}
