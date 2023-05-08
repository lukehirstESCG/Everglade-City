using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AllCollectibles : MonoBehaviour
{
    public TextMeshProUGUI FinishText;

    public GameObject FinishMenu;
    public GameObject CreditsScreen;
    public GameObject MainGamePanel;
    public GameObject Image1;
    public GameObject CreditsText;

    private int CollectiblesFound;
    private int TotalCollectibles;
    public float delay = 25f;

    public UnityEvent<AllCollectibles> AllCollectiblesCompleted;

    private void Start()
    {
        // Sets the FinishMenu to false, collectibles found to 0, and how many total collectibles in the scene.
        FinishMenu.SetActive(false);
        CollectiblesFound = 0;
        TotalCollectibles = FindObjectsOfType<Collectible>().Length;
        CreditsScreen.SetActive(false);
    }

    IEnumerator Credits()
    {
        CreditsScreen.SetActive(true);
        CreditsText.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        yield return new WaitForSeconds(delay);
        CreditsText.SetActive(false);
        yield return new WaitForSeconds(1);

        Image1.SetActive(true);
        yield return new WaitForSeconds(delay);
        Image1.SetActive(false);
        CreditsScreen.SetActive(false);
        Time.timeScale = 0f;
        FinishMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Finished()
    {
        CollectiblesFound++;

        // Have all of the collectibles been found?
        if (CollectiblesFound == TotalCollectibles)
        {
            // End the game.
            Debug.Log("ALL DONE");
            AllCollectiblesCompleted.Invoke(this);

            MainGamePanel.SetActive(false);

            StartCoroutine(Credits());
        }
    }
    public void ContinuePlaying()
    {
        // Resume the game.
        FinishMenu.SetActive(false);
        MainGamePanel.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Museum()
    {
        // Transports the player to a Museum of objects.
        FinishMenu.SetActive(false);
        MainGamePanel.SetActive(false);
        SceneManager.LoadScene("Museum");
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
