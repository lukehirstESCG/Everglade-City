using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValenciaislandLights : MonoBehaviour
{
    public GameObject[] Valencia;

    private void Start()
    {
        Valencia[0].SetActive(true);
        StartCoroutine(LightShow());
    }
    IEnumerator LightShow()
    {
        while (true)
        {
            if (Valencia[0] == true)
            {
                Valencia[0].SetActive(false);
                Valencia[1].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[1] == true)
            {
                Valencia[1].SetActive(false);
                Valencia[2].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[2] == true)
            {
                Valencia[2].SetActive(false);
                Valencia[3].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[3] == true)
            {
                Valencia[3].SetActive(false);
                Valencia[4].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[4] == true)
            {
                Valencia[4].SetActive(false);
                Valencia[5].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[5] == true)
            {
                Valencia[5].SetActive(false);
                Valencia[6].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[6] == true)
            {
                Valencia[6].SetActive(false);
                Valencia[7].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[7] == true)
            {
                Valencia[0].SetActive(true);
                Valencia[1].SetActive(true);
                Valencia[2].SetActive(true);
                Valencia[3].SetActive(true);
                Valencia[4].SetActive(true);
                Valencia[5].SetActive(true);
                Valencia[7].SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (Valencia[0] && Valencia[1] && Valencia[2] && Valencia[3] && Valencia[4] && Valencia[5] && Valencia[6] && Valencia[7] == true)
            {
                Valencia[0].SetActive(false);
                Valencia[1].SetActive(false);
                Valencia[2].SetActive(false);
                Valencia[3].SetActive(false);
                Valencia[4].SetActive(false);
                Valencia[5].SetActive(false);
                Valencia[7].SetActive(false);
                yield return new WaitForSeconds(1);
                Valencia[0].SetActive(true);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
