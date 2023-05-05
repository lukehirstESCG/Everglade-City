using UnityEngine;
using TMPro;

public class CollectibleCounter : MonoBehaviour
{
    public TextMeshProUGUI CollectibleText;
    int count;

    void Start() => UpdateCount();

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        // Once a collectible is found, update the count.
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        // Update the amount collected against the ones still outstanding in the scene.
        CollectibleText.text = $"{count} / {Collectible.total}";
    }
}
