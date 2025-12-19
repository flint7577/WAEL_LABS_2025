using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform groundCheck;

    public float speed = 7.3f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private LayerMask groundLayer;
<<<<<<< Updated upstream
<<<<<<< Updated upstream


    
=======
    private Animator anim;

>>>>>>> Stashed changes
=======
    private Animator anim;

>>>>>>> Stashed changes
    public bool isGrounded = false;
    public float groundCheckRadius = 0.12f; // was 0.02 (too tiny)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        anim = GetComponent<Animator>();

        // Only create GroundCheck if none assigned in Inspector
        if (groundCheck == null)
        {
            GameObject newObj = new GameObject("GroundCheck");
            newObj.transform.SetParent(transform);
            newObj.transform.localPosition = new Vector3(0f, -0.5f, 0f); // under feet (not center)
            groundCheck = newObj.transform;
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Grounded check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float hValue = Input.GetAxis("Horizontal"); //left & right movement

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        rb.linearVelocityX = hValue * speed;

        if (Input.GetButtonDown("Jump")) //jump functionality
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
=======
        // Horizontal movement
        float hValue = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = hValue * speed;

        // Drive animator booleans EVERY frame (matching your Animator parameter names)
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsRunning", Mathf.Abs(hValue) > 0.01f);
        anim.SetBool("IsJumping", !isGrounded);

        // Jump physics (only if grounded)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
=======
        // Horizontal movement
        float hValue = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = hValue * speed;

        // Drive animator booleans EVERY frame (matching your Animator parameter names)
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsRunning", Mathf.Abs(hValue) > 0.01f);
        anim.SetBool("IsJumping", !isGrounded);

        // Jump physics (only if grounded)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
>>>>>>> Stashed changes
            // IsJumping will become true automatically next frame because isGrounded becomes false
        }

        // Fire trigger
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Fire");
        }

        // JumpFire trigger (Fire held + Jump pressed)
        if (Input.GetButton("Fire1") && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("JumpFire");
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    private void OnDrawGizmosSelected()
    {
        if (!groundCheck) return;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}