using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var stats = other.GetComponent<PlayerStats>();
        if (stats) stats.AddCoin(coinValue);

        Debug.Log("Collectible consumed -> destroying.");
        Destroy(gameObject);
    }
}
