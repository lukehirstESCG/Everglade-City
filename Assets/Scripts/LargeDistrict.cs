using System.Collections;
using UnityEngine;
using TMPro;

public class LargeDistrict : MonoBehaviour
{
    public string LargeDistrictName;
    public TextMeshProUGUI MainDistrict;
    public Animator LargeDistrictFade;

    private bool isOnScreen = false;

    private IEnumerator Start()
    {
        Vector3 PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (GetComponent<Collider>().bounds.Contains(PlayerPosition))
        {
            LargeDistrictFade.enabled = true;
            MainDistrict.text = LargeDistrictName;
            isOnScreen = true;

            yield return new WaitForSeconds(3);

            LargeDistrictFade.enabled = false;
            isOnScreen = false;
            MainDistrict.text = "";
        }
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
            LargeDistrictFade.enabled = true;

            // Displays "DISTRICT NAME" on the screen
            isOnScreen = true;

            MainDistrict.text = LargeDistrictName;

            // Wait for 3 seconds

            yield return new WaitForSeconds(3);

            LargeDistrictFade.enabled = false;

            isOnScreen = false;

            MainDistrict.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Is the player in a new LargeDistrict? If so, display the new name
        if (other.CompareTag(("Player")) && other.gameObject.name == "LargeDistrict")
        {
            StartCoroutine(PrimaryDistrictName());
        }    
        
    }
    private void OnTriggerExit(Collider other)
    {
        // Has the player entered a district with a blank name? If so, hide the text.
        if (other.CompareTag(("")))
        {
            isOnScreen = false;
            LargeDistrictFade.enabled = false;
            MainDistrict.text = "";
        }
    }

}
