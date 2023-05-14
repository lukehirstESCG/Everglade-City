using UnityEngine;
using TMPro;

public class DistrictName : MonoBehaviour
{
    public string District;
    public bool DistrictVisible = false;
    public TextMeshProUGUI DistrictText;

    private void Start()
    {
        DistrictText.text = "";
        DistrictVisible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DistrictText.text = District;  
            DistrictVisible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            DistrictText.text = "";
            DistrictVisible = false;
        }
    }
}
