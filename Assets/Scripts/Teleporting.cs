using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    private void OnTriggerEnter(Collider Player)
    {
        Player.transform.position = teleportTarget.transform.position;
        Debug.Log("You have arrived at: " + teleportTarget);
    }
}
