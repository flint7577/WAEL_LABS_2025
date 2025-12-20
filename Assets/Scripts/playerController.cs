using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform groundCheck;

    public float speed = 7.3f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private LayerMask groundLayer;
    private Animator anim;

    public bool isGrounded = false;
    public float groundCheckRadius = 0.12f; // was 0.02 (too tiny)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        anim = GetComponent<Animator>();

        // Only create GroundCheck if none assigned in Inspector
        if (groundCheck == null)
        {
            GameObject newObj = new GameObject("GroundCheck");
            newObj.transform.SetParent(transform);
            newObj.transform.localPosition = new Vector3(0f, -0.5f, 0f); // under feet (not center)
            groundCheck = newObj.transform;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float hValue = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = hValue * speed;

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsRunning", Mathf.Abs(hValue) > 0.01f);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }

        // Fire
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Fire");
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (!groundCheck) return;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
