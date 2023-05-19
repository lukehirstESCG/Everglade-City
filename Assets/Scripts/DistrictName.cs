using UnityEngine;
using TMPro;

public class DistrictName : MonoBehaviour
{
    public string District;
    public TextMeshProUGUI DistrictText;

    private bool isOnScreen = false;

    private void Start()
    {
        isOnScreen = false;
        DistrictText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(("Player")))
        {
            isOnScreen = true;
            DistrictText.text = District;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            isOnScreen = false;
            DistrictText.text = "";
        }
    }
}
