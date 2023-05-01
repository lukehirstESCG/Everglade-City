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
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;
    public GameObject CreditsText;
    private int CollectiblesFound;
    private int TotalCollectibles;
    public float delay = 1f;

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
        Time.timeScale = 1f;
        yield return new WaitForSeconds(delay);
        CreditsText.SetActive(false);

        Image1.SetActive(true);
        yield return new WaitForSeconds(delay);

        Image1.SetActive(false);
        Image2.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image2.SetActive(false);
        Image3.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image3.SetActive(false);
        Image4.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image4.SetActive(false);
        Image5.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image5.SetActive(false);
        Image6.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image6.SetActive(false);
        Image7.SetActive(true);
        yield return new WaitForSeconds(delay);


        Image7.SetActive(false);
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
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
