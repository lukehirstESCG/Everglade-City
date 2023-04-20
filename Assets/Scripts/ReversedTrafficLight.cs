using System.Collections;
using UnityEngine;

public class ReversedTrafficLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    float delay;

    private void Start()
    {
        greenLight.SetActive(true);
        StartCoroutine(ReversedTrafficLightController());

    }
    IEnumerator ReversedTrafficLightController()
    {
        while (true)
        {
            if (greenLight == true)
            {
                yellowLight.SetActive(true);
                greenLight.SetActive(false);
                delay = 2;
                yield return new WaitForSeconds(delay);
            }
            if (yellowLight == true)
            {
                yellowLight.SetActive(false);
                redLight.SetActive(true);
                delay = 5;
                yield return new WaitForSeconds(delay);
            }
            if (redLight == true)
            {
                yellowLight.SetActive(true);
                delay = 2;
                yield return new WaitForSeconds(delay);
            }
            if (redLight && yellowLight == true)
            {
                redLight.SetActive(false);
                yellowLight.SetActive(false);
                greenLight.SetActive(true);
                delay = 5;
                yield return new WaitForSeconds(delay);
            }

        }

    }
}

