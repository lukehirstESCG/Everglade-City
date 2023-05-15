using UnityEngine;
using TMPro;

public class DistrictName : MonoBehaviour
{
    public string District;
    public TextMeshProUGUI DistrictText;

    private void Start()
    {
        DistrictText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(("Player")))
        {
            DistrictText.text = District;  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(("")))
        {
            DistrictText.text = "";
        }
    }
}
