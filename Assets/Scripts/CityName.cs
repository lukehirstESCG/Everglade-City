using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CityName : MonoBehaviour
{
    public string LargeDistrict;
    public TextMeshProUGUI MainDistrict;

    private bool isOnScreen = false;

    private void Start()
    {
        MainDistrict.text = LargeDistrict;
    }

    private void Update()
    {
        OnZPressed();
    }

    private void OnZPressed()
    {
        // Is the player pressing Z, and is the name NOT on the screen?
        if(Input.GetKeyDown(KeyCode.Z)  && !isOnScreen)
        {
            // Starts the coroutine
            StartCoroutine(PrimaryDistrictName());
        }    
    }

    IEnumerator PrimaryDistrictName()
    {
        {
            MainDistrict.text = LargeDistrict;
        }
        // Displays "DISTRICT NAME" on the screen
        isOnScreen = true;

        MainDistrict.text = LargeDistrict;

        // Wait for 3 seconds

        yield return new WaitForSeconds(3);

        isOnScreen = false;

        MainDistrict.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        // Is the player in a new LargeDistrict? If so, display the new name
        MainDistrict.text = LargeDistrict;
        isOnScreen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            isOnScreen = false;
            MainDistrict.text = "";
        }
    }

}
