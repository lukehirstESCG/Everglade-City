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
    public GameObject MainGamePanel;
    private int CollectiblesFound;
    private int TotalCollectibles;

    public UnityEvent<AllCollectibles> AllCollectiblesCompleted;

    private void Start()
    {
        // Sets the FinishMenu to false, collectibles found to 0, and how many total collectibles in the scene.
        FinishMenu.SetActive(false);
        CollectiblesFound = 0;
        TotalCollectibles = FindObjectsOfType<Collectible>().Length;
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
            FinishMenu.SetActive(true);
            Time.timeScale = 0f;
            MainGamePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
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
