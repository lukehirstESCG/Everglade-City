using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    public float offsetX, offsetZ, offsetY;
    public float LerpSpeed;

    private void Update()
    {
        MinimapTravel();
    }
    private void MinimapTravel()
    {
        // If the player enters a building, it tells the camera to offset itself by the amount given.
        transform.position = Vector3.Lerp(transform.position,
        new Vector3(target.position.x + offsetX, transform.position.y + offsetY, target.position.z + offsetZ), LerpSpeed);
    }
}
