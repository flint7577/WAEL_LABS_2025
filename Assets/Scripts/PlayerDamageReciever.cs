using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour
{
    private PlayerStats stats;
    private MonoBehaviour[] scriptsToDisable; // your movement/shooting scripts etc.

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        // Disable all scripts except Stats and this one on death (fast & reliable).
        scriptsToDisable = GetComponents<MonoBehaviour>();
    }

    public void TakeHit()
    {
        // If coin exists, spend it and survive.
        if (stats != null && stats.TryAbsorbHitWithCoin())
            return;

        Debug.Log("Player hit with no coin. Death/lose life.");
        DisableControl();
        GameManager.I.PlayerDied();
    }

    private void DisableControl()
    {
        foreach (var s in scriptsToDisable)
        {
            if (s == null) continue;
            if (s is PlayerStats) continue;
            if (s is PlayerDamageReceiver) continue;
            s.enabled = false;
        }
    }
}
