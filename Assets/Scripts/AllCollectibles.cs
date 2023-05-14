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

    public GameObject[] Finish;
    private int CollectiblesFound;
    private int TotalCollectibles;
    public float delay = 25f;

    public UnityEvent<AllCollectibles> AllCollectiblesCompleted;

    private void Start()
    {
        // Sets the FinishMenu to false, collectibles found to 0, and how many total collectibles in the scene.
        Finish[0].SetActive(false);
        CollectiblesFound = 0;
        TotalCollectibles = FindObjectsOfType<Collectible>().Length;
        Finish[1].SetActive(false);
        Finish[3].SetActive(false);
    }

    IEnumerator Credits()
    {
        Finish[1].SetActive(true);
        Finish[4].SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(delay);

        Finish[4].SetActive(false);
        Finish[3].SetActive(true);
        yield return new WaitForSeconds(delay);
        Finish[3].SetActive(false);

        Finish[1].SetActive(false);
        Finish[0].SetActive(true);
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

            Finish[2].SetActive(false);

            StartCoroutine(Credits());
        }
    }
    public void ContinuePlaying()
    {
        // Resume the game.
        Finish[0].SetActive(false);
        Finish[2].SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Museum()
    {
        // Transports the player to a Museum of objects.
        Finish[0].SetActive(false);
        Finish[2].SetActive(false);
        SceneManager.LoadScene("Museum");
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
