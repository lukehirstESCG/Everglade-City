using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    public GameObject Player;
    public GameObject minimapCamera;

    private void Update()
    {
        AdjustCameraPosition();
    }

    private void AdjustCameraPosition()
    {
        minimapCamera.transform.position = Player.transform.position + new Vector3 (0, 110, 0);
    }
}
