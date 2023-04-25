using UnityEngine;
using UnityEngine.Audio;

public class Soundtrack : MonoBehaviour
{
    void PlaySong()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<AudioManager>().Play("Track1");
        }
    }
    void StopSong()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<AudioManager>().Stop("Track1");
        }
    }
}

