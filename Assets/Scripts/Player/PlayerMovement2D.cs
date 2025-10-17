using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed;
    [Tooltip("This variable controls how fast the player moves")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("Sprint")]
    [Tooltip("This variable controls how fast the player moves while sprinting")]
    [SerializeField] private float sprintSpeed = 7f;
    public bool isSprinting;

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
        if (isSprinting)
        {
            moveSpeed = sprintSpeed;
        }
        else if (!isSprinting)
        {
            moveSpeed = walkSpeed;
        }

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
        moveSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSprinting = true;
        }
        else if (context.canceled)
        {
            isSprinting = false;
        }
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
