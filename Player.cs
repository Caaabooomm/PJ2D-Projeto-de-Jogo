using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Verificação de chão")]
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb2D;
    private Transform groundCheck;
    private bool isGrounded;
    private float moveInput;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // verifcação se esta no chao, retorna um bool true ou false
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // pula com input e verificaçao
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(moveInput * moveSpeed, rb2D.linearVelocity.y);
    }
}