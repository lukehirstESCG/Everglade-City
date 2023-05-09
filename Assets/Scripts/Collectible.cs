using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    private void Awake() => total = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
                OnCollected?.Invoke();
                FindObjectOfType<AudioManager>().Play("Collectible");
                gameObject.SetActive(false);
            }
        }
    }
}