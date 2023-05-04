using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Soundtrack : MonoBehaviour
{

    private bool isPlayingTrack1 = false;
    private bool isPlayingTrack2 = false;
    private float currentTrack = 0;


    private void Update()
    {
        OnEPressed();
        SkipSong();
        StopSong();
    }

    private void OnEPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlaySong());
        }
    }

    IEnumerator PlaySong()
    {
        while (true)
        {
            if (currentTrack == 0)
            {
                FindObjectOfType<AudioManager>().Play("Track1");
                isPlayingTrack1 = true;

                yield return new WaitForSeconds(180);

                FindObjectOfType<AudioManager>().Stop("Track1");
                isPlayingTrack1 = false;
                currentTrack = 1;
            }
            if (currentTrack == 1)
            {
                FindObjectOfType<AudioManager>().Play("Track2");

                isPlayingTrack2 = true;

                yield return new WaitForSeconds(120);

                FindObjectOfType<AudioManager>().Stop("Track2");

                isPlayingTrack2 = false;
                currentTrack = 2;
            }
        }
    }

    private void SkipSong()
    {
        if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack1 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;

            FindObjectOfType<AudioManager>().Play("Track2");
            isPlayingTrack2 = true;
        }
    }
    private void StopSong()
    {
        {
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack1 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track1");
                isPlayingTrack1 = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack2 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track2");
                isPlayingTrack2 = false;
            }
        }
    }
}

