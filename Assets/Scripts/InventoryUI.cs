using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI collectibleText;

    public int TotalCollectibles;
    

    // Start is called before the first frame update
    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateCollectibleText(PlayerInventory inventory)
    {
        collectibleText.text = $"Collectibles collected: {inventory.NumberOfCollectibles} / {TotalCollectibles}";
    }
}
