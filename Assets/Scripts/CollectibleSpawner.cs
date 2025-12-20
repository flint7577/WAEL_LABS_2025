using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [Tooltip("List of collectible prefabs to choose from.")]
    public GameObject[] collectiblePrefabs;

    [Tooltip("Exactly 5 transforms in close range on one screen.")]
    public Transform[] spawnPoints;

    private void Start()
    {
        SpawnAll();
    }

    public void SpawnAll()
    {
        if (collectiblePrefabs == null || collectiblePrefabs.Length == 0) return;
        if (spawnPoints == null || spawnPoints.Length == 0) return;

        foreach (var sp in spawnPoints)
        {
            var prefab = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];
            Instantiate(prefab, sp.position, Quaternion.identity);
        }
    }
}
