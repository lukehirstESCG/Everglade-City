using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    public GameObject[] Welcome;

    private void Start()
    {
        Welcome[0].SetActive(true);
        Welcome[1].SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Acknowledge()
    {
        Welcome[0].SetActive(false);
        Welcome[1].SetActive(true);
        Time.timeScale = 1f;
    }
}
