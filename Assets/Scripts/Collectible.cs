using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider Player)
    {
        PlayerInventory inventory = Player.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.CollectibleCollected();
            gameObject.SetActive(false);
        }
    }
}
