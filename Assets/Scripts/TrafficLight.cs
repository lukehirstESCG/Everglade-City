using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    private void Start()
    {
        StartCoroutine(TrafficLightCoroutine());
        redLight.SetActive(true);
    }

    IEnumerator TrafficLightCoroutine()
    {
        while (true)
        {
            if (greenLight == true)
            {
                greenLight.SetActive(false);
                yellowLight.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            if (yellowLight == true)
            {
                yellowLight.SetActive(false);
                redLight.SetActive(true);
                yield return new WaitForSeconds(10f);
            }
            if (redLight == true)
            {
                yellowLight.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            if (redLight && yellowLight == true)
            {
                redLight.SetActive(false);
                yellowLight.SetActive(false);
                greenLight.SetActive(true);
                yield return new WaitForSeconds(10f);
            }
            if (greenLight == true)
            {
                yellowLight.SetActive(true);
                greenLight.SetActive (false);
                yield return new WaitForSeconds(2f);
            }

           }
        }
    }
