using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI SettingText;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);

        SettingText.text = "";
    }
}
