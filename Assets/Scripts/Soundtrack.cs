using System.Collections;
using UnityEngine;
using TMPro;

public class Soundtrack : MonoBehaviour
{
    private bool isPlayingTrack1 = false;
    private bool isPlayingTrack2 = false;
    private bool isPlayingTrack3 = false;
    private bool isPlayingTrack4 = false;
    private bool isPlayingTrack5 = false;
    private Coroutine StartSong;
    float currentTrack = 0;
    public string[] Track = { "track1", "track2", "track3", "track4", "track5" };
    public TextMeshProUGUI trackName;

    private void Start()
    {
        isPlayingTrack1 = false;
        trackName.text = "";
    }

    private void Update()
    {
        OnEPressed();
        SkipSong();
        StopSong();
    }

    private void OnEPressed()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
          // Unity 5.3 Onwards requires this to work properly.
          StartSong = StartCoroutine(PlaySong());
        }
    }

    private IEnumerator PlaySong()
    {
        currentTrack = 0;
        while (currentTrack < 5)
        {
            if (currentTrack == 0)
            {
                FindObjectOfType<AudioManager>().Play("Track1");
                isPlayingTrack1 = true;
                trackName.text = $"{Track[0]}";
                currentTrack++;

                yield return new WaitForSeconds(179);

                FindObjectOfType<AudioManager>().Stop("Track1");
                isPlayingTrack1 = false;
                currentTrack = 1;
            }
            if (currentTrack == 1)
            {
                FindObjectOfType<AudioManager>().Play("Track2");

                isPlayingTrack2 = true;
                trackName.text = $"{Track[1]}";

                yield return new WaitForSeconds(183);

                FindObjectOfType<AudioManager>().Stop("Track2");

                isPlayingTrack2 = false;
                currentTrack = 2;
            }
            if (currentTrack == 2)
            {
                FindObjectOfType<AudioManager>().Play("Track3");

                isPlayingTrack3 = true;
                trackName.text = $"{Track[2]}";


                yield return new WaitForSeconds(204);

                FindObjectOfType<AudioManager>().Stop("Track3");
                isPlayingTrack3 = false;
                currentTrack = 3;
            }
            if (currentTrack == 3)
            {
                FindObjectOfType<AudioManager>().Play("Track4");

                isPlayingTrack4 = true;
                trackName.text = $"{Track[3]}";
                currentTrack++;

                yield return new WaitForSeconds(171);

                FindObjectOfType<AudioManager>().Stop("Track4");
                isPlayingTrack4 = false;
                currentTrack = 4;
            }
            if (currentTrack == 4)
            {
                FindObjectOfType<AudioManager>().Play("Track5");

                isPlayingTrack5 = true;
                trackName.text = $"{Track[4]}";
                currentTrack++;

                yield return new WaitForSeconds(5);

                FindObjectOfType<AudioManager>().Stop("Track5");
                isPlayingTrack5 = false;
            }
            if (currentTrack > 5)
            {
                FindObjectOfType<AudioManager>().Stop(Track[0]);
                yield return new WaitForSeconds(2f);
                StopCoroutine(StartSong);
                yield break;
            }
        }
    }

    private void SkipSong()
    {
        if (Input.GetKeyDown(KeyCode.O) && isPlayingTrack1 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;

            FindObjectOfType<AudioManager>().Play("Track2");
            isPlayingTrack2 = true;
            trackName.text = $"{Track[1]}";
            currentTrack = 1;
        }
        else if (Input.GetKeyDown(KeyCode.O) && isPlayingTrack2 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track2");
            isPlayingTrack2 = false;

            FindObjectOfType<AudioManager>().Play("Track3");
            isPlayingTrack3 = true;
            trackName.text = $"{Track[2]}";
            currentTrack = 2;
        }
        else if (Input.GetKeyDown(KeyCode.O) && isPlayingTrack3 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track3");
            isPlayingTrack3 = false;

            FindObjectOfType<AudioManager>().Play("Track4");
            isPlayingTrack4 = true;
            trackName.text = $"{Track[3]}";
            currentTrack = 3;
        }
        else if (Input.GetKeyDown(KeyCode.O) && isPlayingTrack4 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track4");
            isPlayingTrack4 = false;

            FindObjectOfType<AudioManager>().Play("Track5");
            isPlayingTrack5 = true;
            trackName.text = $"{Track[4]}";
            currentTrack = 4;
        }
        else if (Input.GetKeyDown(KeyCode.O) && isPlayingTrack5 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track5");
            isPlayingTrack4 = false;

            FindObjectOfType<AudioManager>().Play("Track1");
            isPlayingTrack1 = true;
            trackName.text = $"{Track[0]}";
            currentTrack = 0;

        }
    }
    private void StopSong()
    {
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Stops the song from playing (Any of these WILL stop the coroutine).
                StopCoroutine(StartSong);
                FindObjectOfType<AudioManager>().Stop("Track1");
                FindObjectOfType<AudioManager>().Stop("Track2");
                FindObjectOfType<AudioManager>().Stop("Track3");
                FindObjectOfType<AudioManager>().Stop("Track4");
                FindObjectOfType<AudioManager>().Stop("Track5");

                isPlayingTrack1 = false;
                isPlayingTrack2 = false;
                isPlayingTrack3 = false;
                isPlayingTrack4 = false;
                isPlayingTrack5 = false;

                trackName.text = "";
            }
        }
    }
}

