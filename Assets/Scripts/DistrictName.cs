using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistrictName : MonoBehaviour
{
    public string District;
    public TextMeshProUGUI DistrictText;

    private void Start()
    {
        string DistrictText = "";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DistrictText.text = "" + District;  
        }
    }
    private void OnCollisonExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            DistrictText.text = "" + District;
        }
    }
}
