using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public ParticleSystem Rain;
    private float randomValue;
    private float thresholdValue;

    private void Start()
    {
        thresholdValue = 0.5f;
        randomValue = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomValue < thresholdValue)
        {
            Rain.Stop();
            Debug.Log("Stopping Rain");
        }
        else
        {
            randomValue = Random.value;
            if (randomValue > thresholdValue)
            {
                Rain.Play();
                Debug.Log("Raining!");
            }
        }
    }
}
