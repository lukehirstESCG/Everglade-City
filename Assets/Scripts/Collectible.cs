using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    private void Awake() => total++;

    private void OnDisable()
    {
        total--;
    }

    private void OnTriggerExit(Collider Player)
    {
        if (Player.CompareTag("Player"))
        {
            // Finds all collectibles in the scene.
            AllCollectibles allCollectibles = FindObjectOfType<AllCollectibles>();

            // Have all collectibles been collected?
            if (allCollectibles != null)
            {
                // Tells the game to finish
                allCollectibles.Finished();
            }
            {
                // Adds the collectible to the count, and sets it to false
                OnCollected.Invoke();
                FindObjectOfType<AudioManager>().Play("Collectible");
                Destroy(gameObject);
            }
        }
    }
}