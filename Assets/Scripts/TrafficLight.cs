using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    float delay;

    private void Start()
    {
        redLight.SetActive(true);
        StartCoroutine(TrafficLightController());

    }
    IEnumerator TrafficLightController()
    {
        while (true)
        {
            if (redLight == true)
            {
                yellowLight.SetActive(true);
                greenLight.SetActive(false);
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
        }


    }

}
