using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float fireInterval = 1.0f;
    public float fireRange = 8f;
    public float projectileSpeed = 8f;

    private Transform player;
    private float t;

    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    private void Update()
    {
        if (!player) return;

        float d = Vector2.Distance(transform.position, player.position);
        if (d > fireRange) return;

        t += Time.deltaTime;
        if (t >= fireInterval)
        {
            t = 0f;
            Fire();
        }
    }

    private void Fire()
    {
        if (!projectilePrefab || !firePoint) return;

        var go = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Aim horizontally at player (fastest)
        var dir = (player.position.x >= firePoint.position.x) ? Vector2.right : Vector2.left;

        var p = go.GetComponent<Projectile>();
        if (p) p.Launch(dir, projectileSpeed);

        Debug.Log("Turret fired.");
    }
}
