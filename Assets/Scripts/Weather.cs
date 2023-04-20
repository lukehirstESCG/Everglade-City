using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weather : MonoBehaviour
{
    public ParticleSystem Rain;
    private float diceValue;
    private float thresholdValue;

    private void Start()
    {
        thresholdValue = 3f;
        diceValue = Random.Range(1, 7);
    }

    void Raining()
    {
        if (Rain.isPlaying)
        {
            if (diceValue < thresholdValue)
            {
                Rain.Stop();
                Debug.Log("Stopping Rain");
            }
        }
        else
        {
            diceValue = Random.Range(1, 7);
            if (diceValue >= thresholdValue)
            {
                Rain.Play();
                Debug.Log("Raining!");
            }
        }
    }
}
