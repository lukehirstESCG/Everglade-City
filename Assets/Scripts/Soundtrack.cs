using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    private string currentTrackName = "";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!string.IsNullOrEmpty(currentTrackName))
            {
                FindObjectOfType<AudioManager>().Stop(currentTrackName);
            }

            currentTrackName = "Track1";
            FindObjectOfType<AudioManager>().Play("Track1");
            Invoke("PlayTrack2", 155.4f);
        }
    }

    void PlayTrack2()
    {
        FindObjectOfType<AudioManager>().Stop("Track1");

        currentTrackName = "Track2";
        FindObjectOfType<AudioManager>().Play("Track2");
        Invoke("StopTrack2", 192.6f);
    }

    void StopTrack2()
    {
        FindObjectOfType<AudioManager>().Stop("Track2");
        currentTrackName = "";
    }

}

