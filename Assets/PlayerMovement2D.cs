using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement")]
    [Tooltip("This variable controls how fast the player moves")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Jumping")]
    [Tooltip("This variable controls how high the player can jump")]
    [SerializeField] private float jumpPower = 10f;
    [Tooltip("Controls how many jumps the player can do")]
    [SerializeField] private int maxJumps = 2;
    int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    [Tooltip("Player base gravity value")]
    [SerializeField] private float baseGravity = 2f;
    [Tooltip("The maximum value the fall speed will increase to")]
    [SerializeField] private float maxFallSpeed = 18f;
    [Tooltip("Increases the player fall speed")]
    [SerializeField] private float fallSpeedMultiplier = 2f;

    float horizontalMovement;

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        GroundCheck();
        Gravity();
    }

    private void Gravity()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; //Fall increasingly faster
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
                if (context.performed)
                {
                    //Hold down jump button = full height
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                    jumpsRemaining--;
                }
                else if (context.canceled)
                {
                    //Light tap of jump button = half the height
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                    jumpsRemaining--;
                }
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
