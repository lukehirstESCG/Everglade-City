using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot_matrix_sign : MonoBehaviour
{
    public GameObject DMText1;
    public GameObject DMText2;
    public GameObject DMText3;
    public GameObject DMText4;
    public GameObject DMText5;

    private void Start()
    {
        DMText1.SetActive(true);
        StartCoroutine(DotMatrixDisplay());
    }
    IEnumerator DotMatrixDisplay()
    {
        while (true)
        {
            if (DMText1 == true)
            {
                DMText1.SetActive(false);
                DMText2.SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText2 == true)
            {
                DMText2.SetActive(false);
                DMText3.SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText3 == true)
            {
                DMText3.SetActive(false);
                DMText4.SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText4 == true)
            {
                DMText4.SetActive(false);
                DMText5.SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText5 == true)
            {
                DMText5.SetActive(false);
                DMText1.SetActive(true);
                yield return new WaitForSeconds(10);
            }
        }
    }
}
