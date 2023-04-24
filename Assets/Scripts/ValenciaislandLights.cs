using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValenciaislandLights : MonoBehaviour
{
    public GameObject V;
    public GameObject A;
    public GameObject L;
    public GameObject E;
    public GameObject N;
    public GameObject C;
    public GameObject I;
    public GameObject A2;

    private void Start()
    {
        V.SetActive(true);
        StartCoroutine(LightShow());
    }
    IEnumerator LightShow()
    {
        while (true)
        {
            if (V == true)
            {
                V.SetActive(false);
                A.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (A == true)
            {
                A.SetActive(false);
                L.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (L == true)
            {
                L.SetActive(false);
                E.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (E == true)
            {
                E.SetActive(false);
                N.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (N == true)
            {
                N.SetActive(false);
                C.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (C == true)
            {
                C.SetActive(false);
                I.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (I == true)
            {
                I.SetActive(false);
                A2.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (A2 == true)
            {
                V.SetActive(true);
                A.SetActive(true);
                L.SetActive(true);
                E.SetActive(true);
                N.SetActive(true);
                C.SetActive(true);
                I.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            if (V && A && L && E && N && C && I && A2 == true)
            {
                V.SetActive(false);
                A.SetActive(false);
                L.SetActive(false);
                E.SetActive(false);
                N.SetActive(false);
                C.SetActive(false);
                I.SetActive(false);
                A2.SetActive(false);
                yield return new WaitForSeconds(1);
                V.SetActive(true);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
