using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 1;

    public void Hit(int dmg = 1)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Debug.Log($"{name} destroyed.");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player bullets reuse Projectile, tagged Projectile.
        if (other.CompareTag("Projectile"))
        {
            Hit(1);
            Destroy(other.gameObject);
        }
    }
}
