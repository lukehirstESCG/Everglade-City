using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject MainGamePanel;
    public AudioSource Menu;
    public AudioSource Back;
    public static int total;

    private void Start()
    {
        pauseMenu.SetActive(false);
        MainGamePanel.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(isPaused)
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
        MainGamePanel.SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Menu.ignoreListenerPause = true;
        Back.ignoreListenerPause = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        MainGamePanel.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FrontEnd");
        AudioListener.pause = true;
    }
}
