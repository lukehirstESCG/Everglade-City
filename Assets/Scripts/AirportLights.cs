using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportLights : MonoBehaviour
{
    public GameObject AirportLightBulb;

    private void Start()
    {
        // Sets the airport light bulb to false, and starts the coroutine
        AirportLightBulb.SetActive(true);
        StartCoroutine(AirportLighting());
    }
    IEnumerator AirportLighting()
    {
        while (true)
        {
            // Is the airport light on?
            if (AirportLightBulb == true)
            {
                // Turn off
                AirportLightBulb.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            // is the Airport light off?
            if (AirportLightBulb == false)
            {
                // Turn on
                AirportLightBulb.SetActive(true);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
