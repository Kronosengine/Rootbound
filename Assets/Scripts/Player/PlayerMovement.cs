using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    int count = 0;
    int count1 = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (isGrounded )
        {
            count = 0;
            count1 = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && count < 1)
        {
            float currentJumpForce = count == 0 ? jumpForce : jumpForce * 1.5f;
            rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
            count++;
            
        }
        if (Input.GetKeyDown(KeyCode.R) && isGrounded)
        {
            if (Input.GetKey(KeyCode.D)) // Используем GetKey, а не GetKeyDown
            {
                rb.velocity = new Vector2(jumpForce * 10, rb.velocity.y);
            }
            // Рывок влево
            else if (Input.GetKey(KeyCode.A)) // Используем GetKey, а не GetKeyDown
            {
                rb.velocity = new Vector2(-jumpForce * 10, rb.velocity.y);
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.Space) && count1 == 0)
            {
                float currentJumpForce = count == 0 ? jumpForce : jumpForce * 1.5f;
                rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
                count1++;
            }
                
        }
        

    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
