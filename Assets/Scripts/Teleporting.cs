using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
    public GameObject minimapCamera;

    private void OnTriggerEnter(Collider Player)
    {
        Player.transform.position = teleportTarget.transform.position;
        Debug.Log("You have arrived at: " + teleportTarget);
        Vector3 abovePlayer = teleportTarget.transform.position + new Vector3(0, 120, 0);
        minimapCamera.transform.position = abovePlayer;
    }
}
