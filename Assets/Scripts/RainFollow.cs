using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{
    public Transform Rain;
    public Transform Player;

    private void Update()
    {
        FollowRain();
    }

    private void FollowRain()
    {
        Rain.transform.position = Player.transform.position;
    }
}
