using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rb;

    float speed = 7.3f;
    float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxis("Horizontal");

        rb.linearVelocityX = hValue * speed;

        //bool jumpPressed = Input.GetButtonDown("Jump");

        //rb.linearVelocityY = jumpPressed (rb.gravityScale + jumpForce);
    }
}
