using System.Collections;
using UnityEngine;

public class UKZebraCrossing : MonoBehaviour
{
    public GameObject zebracrossingLight;

    private void Start()
    {
        zebracrossingLight.SetActive(true);
        StartCoroutine(Crossing());
    }

    IEnumerator Crossing()
    {
        while (true)
        {
            zebracrossingLight.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            zebracrossingLight.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
