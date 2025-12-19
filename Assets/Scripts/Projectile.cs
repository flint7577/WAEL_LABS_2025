using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 4f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 dir, float speed)
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir.normalized * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var dmg = other.GetComponent<PlayerDamageReceiver>();
            if (dmg) dmg.TakeHit();
            Destroy(gameObject);
            return;
        }

        // Hit ground/platform/etc -> destroy
        if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
