using System.Collections;
using UnityEngine;

public class dot_matrix_sign : MonoBehaviour
{
    public GameObject[] DMText;

    private void Start()
    {
        DMText[0].SetActive(true);
        StartCoroutine(DotMatrixDisplay());
    }
    IEnumerator DotMatrixDisplay()
    {
        while (true)
        {
            if (DMText[0] == true)
            {
                DMText[0].SetActive(false);
                DMText[1].SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText[1] == true)
            {
                DMText[1].SetActive(false);
                DMText[2].SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText[2] == true)
            {
                DMText[2].SetActive(false);
                DMText[3].SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText[3] == true)
            {
                DMText[3].SetActive(false);
                DMText[4].SetActive(true);
                yield return new WaitForSeconds(10);
            }
            if (DMText[4] == true)
            {
                DMText[4].SetActive(false);
                DMText[0].SetActive(true);
                yield return new WaitForSeconds(10);
            }
        }
    }
}
