using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Soundtrack : MonoBehaviour
{

    private bool isPlayingTrack1 = false;
    private bool isPlayingTrack2 = false;
    

   private void Update()
    {
        OnRPressed();
        SkipSong();
        StopSong();
    }

    private void OnRPressed()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(PlaySong());
        }
    }

    IEnumerator PlaySong()
    {
        while (true)
        {
            FindObjectOfType<AudioManager>().Play("Track1");
            isPlayingTrack1 = true;

            yield return new WaitForSeconds(180);

            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;

            FindObjectOfType<AudioManager>().Play("Track2");
            isPlayingTrack1 = false;
            
            isPlayingTrack2 = true;

            yield return new WaitForSeconds(120);
        }
    }

    private void SkipSong()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayingTrack1 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;

            FindObjectOfType<AudioManager>().Play("Track2");
            isPlayingTrack2 = true;
        }
    }

    private void StopSong()
    {
        if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack1 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;
        }
        if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack2 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track2");
            isPlayingTrack2 = false;
        }
    }
}

