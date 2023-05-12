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
    private float currentTrack = 0;
    public string track1;
    public string track2;
    public string track3;
    public string track4;
    public string track5;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlaySong());
        }
    }

    IEnumerator PlaySong()
    {
        while (currentTrack <= 4)
        {
            if (currentTrack == 0)
            {
                FindObjectOfType<AudioManager>().Play("Track1");
                isPlayingTrack1 = true;
                trackName.text = $"{track1}";

                yield return new WaitForSeconds(179);

                FindObjectOfType<AudioManager>().Stop("Track1");
                isPlayingTrack1 = false;
                currentTrack = 1;
            }
            if (currentTrack == 1)
            {
                FindObjectOfType<AudioManager>().Play("Track2");

                isPlayingTrack2 = true;
                trackName.text = $"{track2}";

                yield return new WaitForSeconds(183);

                FindObjectOfType<AudioManager>().Stop("Track2");

                isPlayingTrack2 = false;
                currentTrack = 2;
            }
            if (currentTrack == 2)
            {
                FindObjectOfType<AudioManager>().Play("Track3");

                isPlayingTrack3 = true;
                trackName.text = $"{track3}";

                yield return new WaitForSeconds(204);

                FindObjectOfType<AudioManager>().Stop("Track3");
                isPlayingTrack3 = false;
                currentTrack = 3;
            }
            if (currentTrack == 3)
            {
                FindObjectOfType<AudioManager>().Play("Track4");

                isPlayingTrack4 = true;
                trackName.text = $"{track4}";

                yield return new WaitForSeconds(171);

                FindObjectOfType<AudioManager>().Stop("Track4");
                isPlayingTrack4 = false;
                currentTrack = 4;
            }
            if (currentTrack == 4)
            {
                FindObjectOfType<AudioManager>().Play("Track5");

                isPlayingTrack5 = true;
                trackName.text = $"{track5}";

                yield return new WaitForSeconds(5);

                FindObjectOfType<AudioManager>().Stop("Track5");
                isPlayingTrack5 = false;
            }
            break;
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
            trackName.text = $"{track2}";
            currentTrack = 1;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack2 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track2");
            isPlayingTrack2 = false;

            FindObjectOfType<AudioManager>().Play("Track3");
            isPlayingTrack3 = true;
            trackName.text = $"{track3}";
            currentTrack = 2;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack3 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track3");
            isPlayingTrack3 = false;

            FindObjectOfType<AudioManager>().Play("Track4");
            isPlayingTrack4 = true;
            trackName.text = $"{track4}";
            currentTrack = 3;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack4 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track4");
            isPlayingTrack4 = false;

            FindObjectOfType<AudioManager>().Play("Track5");
            isPlayingTrack5 = true;
            trackName.text = $"{track5}";
            currentTrack = 4;
        }
        else if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack5 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track5");
            isPlayingTrack4 = false;

            FindObjectOfType<AudioManager>().Play("Track1");
            isPlayingTrack1 = true;
            trackName.text = $"{track1}";
            currentTrack = 0;

        }
    }
    private void StopSong()
    {
        {
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack1 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track1");
                isPlayingTrack1 = false;
                trackName.text = "";
                StopCoroutine(PlaySong());
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack2 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track2");
                isPlayingTrack2 = false;
                trackName.text = "";
                StopCoroutine(PlaySong());
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack3 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track3");
                isPlayingTrack3 = false;
                trackName.text = "";
                StopCoroutine(PlaySong());
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack4 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track4");
                isPlayingTrack4 = false;
                trackName.text = "";
                StopCoroutine(PlaySong());
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack5 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track5");
                isPlayingTrack5 = false;
                trackName.text = "";
                StopCoroutine(PlaySong());
            }
        }
    }
}

