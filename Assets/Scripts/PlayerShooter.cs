using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 12f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        if (!bulletPrefab || !firePoint) return;

        var go = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Shoot in facing direction by localScale.x sign (cheap & common)
        float sign = transform.localScale.x >= 0 ? 1f : -1f;
        Vector2 dir = sign > 0 ? Vector2.right : Vector2.left;

        var b = go.GetComponent<Projectile>();
        if (b) b.Launch(dir, bulletSpeed);

        Debug.Log("Player shot.");
    }
}
