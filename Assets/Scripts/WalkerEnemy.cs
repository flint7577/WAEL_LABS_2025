using UnityEngine;

public class WalkerEnemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundAheadCheck;
    public LayerMask groundMask;
    public float checkDistance = 0.3f;

    private int dir = 1;

    private void Update()
    {
        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);

        // Edge detect: if no ground ahead, flip
        if (groundAheadCheck)
        {
            var hit = Physics2D.Raycast(groundAheadCheck.position, Vector2.down, checkDistance, groundMask);
            if (!hit) Flip();
        }
    }

    private void Flip()
    {
        dir *= -1;
        var s = transform.localScale;
        s.x = Mathf.Abs(s.x) * dir;
        transform.localScale = s;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDamageReceiver>()?.TakeHit();
        }
    }
}
