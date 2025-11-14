using UnityEngine;

public class playerController : MonoBehaviour
{

    public Transform groundCheck;

    public float speed = 7.3f; //movement speed
    public float jumpForce = 5f; //jump speed

    Rigidbody2D rb;

    private LayerMask groundLayer;


    
    public bool isGrounded = false;
    public float groundCheckRadius = 0.02f;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float hValue = Input.GetAxis("Horizontal"); //left & right movement

        rb.linearVelocityX = hValue * speed;

        if (Input.GetButtonDown("Jump")) //jump functionality
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
