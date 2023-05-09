using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI SettingText;

    private bool Setting = false;

    private IEnumerator Start()
    {
        Setting = true;

        yield return new WaitForSeconds(5f);

        Setting = false;
        SettingText.text = "";
    }
}
