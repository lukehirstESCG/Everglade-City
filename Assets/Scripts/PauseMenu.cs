using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] Panels;
    public bool isPaused;
    public AudioSource[] Sounds;
    public static int total;

    private void Start()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(true);
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
        Panels[0].SetActive(true);
        Panels[1].SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Sounds[0].ignoreListenerPause = true;
        Sounds[1].ignoreListenerPause = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResumeGame()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(true);
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
}
