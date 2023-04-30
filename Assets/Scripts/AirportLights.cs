using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportLights : MonoBehaviour
{
    public GameObject AirportLightBulb;

    private void Start()
    {
        AirportLightBulb.SetActive(true);
        StartCoroutine(AirportLighting());
    }
    IEnumerator AirportLighting()
    {
        while (true)
        {
            if (AirportLightBulb == true)
            {
                AirportLightBulb.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            if (AirportLightBulb == false)
            {
                AirportLightBulb.SetActive(true);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
