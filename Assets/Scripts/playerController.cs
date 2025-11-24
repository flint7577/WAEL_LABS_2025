using UnityEngine;

public class playerController : MonoBehaviour
{

    public Transform groundCheck;

    public float speed = 7.3f; //movement speed
    public float jumpForce = 5f; //jump speed

    Rigidbody2D rb;

    private LayerMask groundLayer;

    private Animator anim;
    
    public bool isGrounded = false;
    public float groundCheckRadius = 0.02f;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        groundLayer = LayerMask.GetMask("Ground");

        anim = GetComponent<Animator>();

        //initialize ground check POOsition
        GameObject newObj = new GameObject("GroundCheck");
        newObj.transform.SetParent(transform);
        newObj.transform.localPosition = Vector3.zero;
        groundCheck = newObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //left & right movement
        float hValue = Input.GetAxis("Horizontal"); 
        rb.linearVelocityX = hValue * speed;


        //jump functionality
        if (Input.GetButtonDown("Jump")) 
        {
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);

            anim.SetBool("isJumping", !isGrounded); //jump animation
        }

        //attack animation using "Fire1"
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Fire");
        }

        //fire key + jump key = jump attack animation
        if (Input.GetButton("Fire1") && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("JumpFire");
        }

    }
}
