using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coins = 0;

    public void AddCoin(int amount = 1)
    {
        coins += amount;
        Debug.Log($"Coin +{amount}. Total: {coins}");
    }

    // Returns true if it absorbed the hit (spent a coin).
    public bool TryAbsorbHitWithCoin()
    {
        if (coins > 0)
        {
            coins--;
            Debug.Log($"Coin absorbed hit. Coins left: {coins}");
            return true;
        }
        return false;
    }

    public void ResetStats()
    {
        coins = 0;
    }
}
