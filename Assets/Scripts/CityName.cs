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
        if(Input.GetKeyDown(KeyCode.Z) && !isOnScreen)
        {
            StartCoroutine(PrimaryDistrictName());
        }    
    }

    IEnumerator PrimaryDistrictName()
    {
        // Where is the Player currently at?
        Vector3 PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Is the player currently within the district?
        if (GetComponent<Collider>().bounds.Contains(PlayerPosition))
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

    private void OnTriggerEnter(Collider other)
    {
        // Is the player in a new LargeDistrict? If so, display the new name
        if (other.gameObject.tag == "Player" && other.gameObject.name == "LargeDistrict")
        {
            StartCoroutine(PrimaryDistrictName());
        }    
        
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
