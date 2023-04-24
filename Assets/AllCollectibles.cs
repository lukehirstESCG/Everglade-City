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
    public int AllCollectiblesFound { get; private set; }
    private int TotalCollectibles;

    public UnityEvent<AllCollectibles> AllCollectiblesCompleted;

    private void Start()
    {
        FinishMenu.SetActive(false);
    }
    public void Finished(PlayerInventory inventory)
    {
        if (TotalCollectibles >= inventory.NumberOfCollectibles)
        {
            Debug.Log("ALL DONE");
            AllCollectiblesFound++;
            AllCollectiblesCompleted.Invoke(this);
            FinishMenu.SetActive(true);
            Time.timeScale = 0f;
            MainGamePanel.SetActive(false);
        }
    }
    public void ContinuePlaying()
    {
        FinishMenu.SetActive(false);
        MainGamePanel.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
    public void Museum()
    {
        FinishMenu.SetActive(false);
        MainGamePanel.SetActive(false);
        SceneManager.LoadScene("Museum");
        AudioListener.pause = true;
    }


}
