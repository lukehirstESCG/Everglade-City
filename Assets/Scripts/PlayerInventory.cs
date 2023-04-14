using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectibles { get;  private set; }

    public UnityEvent<PlayerInventory> OnCollectibleCollected;

    public void CollectibleCollected()
    {
        NumberOfCollectibles++;
        OnCollectibleCollected.Invoke(this);
    }


}
