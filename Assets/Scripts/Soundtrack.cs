using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class Soundtrack : MonoBehaviour
{

    private bool isPlayingTrack1 = false;
    private bool isPlayingTrack2 = false;
    private bool isPlayingTrack3 = false;
    private float currentTrack = 0;
    public string track1;
    public string track2;
    public string track3;
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
        while (currentTrack < 3)
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
            break;
        }
    }

    private void SkipSong()
    {
        if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack1 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
            isPlayingTrack1 = false;

            if (!isPlayingTrack2)
            {
                FindObjectOfType<AudioManager>().Play("Track2");
                isPlayingTrack2 = true;
                trackName.text = $"{track2}";
                currentTrack = 2;
            }
        }
      if (Input.GetKeyDown(KeyCode.T) && isPlayingTrack2 == true)
        {
            FindObjectOfType<AudioManager>().Stop("Track2");
            isPlayingTrack2 = false;

            if (!isPlayingTrack3)
            {
                FindObjectOfType<AudioManager>().Play("Track3");
                isPlayingTrack3 = true;
                trackName.text = $"{track3}";
                currentTrack = 3;
            }
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
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack2 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track2");
                isPlayingTrack2 = false;
                trackName.text = "";
            }
            if (Input.GetKeyDown(KeyCode.R) && isPlayingTrack3 == true)
            {
                FindObjectOfType<AudioManager>().Stop("Track3");
                isPlayingTrack3 = false;
                trackName.text = "";
            }
        }
    }
}

