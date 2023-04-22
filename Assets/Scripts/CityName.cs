using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityName : MonoBehaviour
{
    public string LargeDistrict;
    public TextMeshProUGUI MainDistrict;

    private bool isOnScreen = false;

    private void Start()
    {
        MainDistrict.text = "";
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
        // Displays "DISTRICT NAME" on the screen
        isOnScreen = true;

        MainDistrict.text = LargeDistrict;

        // Wait for 3 seconds

        yield return new WaitForSeconds(3);

        isOnScreen = false;

        MainDistrict.text = "";
    }

}
