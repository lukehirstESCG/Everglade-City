using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    // If we have already started the game, then set this to false.
    private static bool StartedGame = false;

    void Awake()
    {
        // Have we not started the game before?
        if (StartedGame != true)
        {
            // If that's true, then have the initial counter.
            total++;
            StartedGame = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Finds all collectibles in the scene.
            AllCollectibles allCollectibles = FindObjectOfType<AllCollectibles>();

            // Have all collectibles been collected?
            if (allCollectibles != null)
            {
                // Tells the game to finish
                allCollectibles.Finished();
            }
            else
            {
                // Adds the collectible to the count, and sets it to false
                OnCollected.Invoke();
                FindObjectOfType<AudioManager>().Play("Collectible");
                Destroy(gameObject);
            }
        }
    }
}
