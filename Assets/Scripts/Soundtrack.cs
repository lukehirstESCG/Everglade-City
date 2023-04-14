using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    private string currentTrackName = "";

    private void Start()
    {
        StartCoroutine(MusicList());
    }
    IEnumerator MusicList()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.R))
            {
                {
                    if (!string.IsNullOrEmpty(currentTrackName))
                    {
                        FindObjectOfType<AudioManager>().Stop(currentTrackName);
                    }
                }
                currentTrackName = "Track1";
                FindObjectOfType<AudioManager>().Play("Track1");
                yield return new WaitForSeconds(155.4f);
                FindObjectOfType<AudioManager>().Stop("Track1");

                currentTrackName = "Track2";
                FindObjectOfType<AudioManager>().Play("Track2");
                yield return new WaitForSeconds(192.6f);
                FindObjectOfType<AudioManager>().Stop("Track2");
            }
                
        }
    }
}
