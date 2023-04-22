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
        DistrictText.text = District;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DistrictText.text = District;  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            DistrictText.text = "";
        }
    }
}
