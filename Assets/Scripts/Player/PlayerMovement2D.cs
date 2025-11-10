using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

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
    [SerializeField] private Vector2 smallJumpCheckSize = new Vector2(0.5f, 2.5f);
    public LayerMask groundLayer;
    public LayerMask grabObjectLayer;

    [Header("Gravity")]
    [Tooltip("Player base gravity value")]
    [SerializeField] private float baseGravity = 1f;
    [Tooltip("The maximum value the fall speed will increase to")]
    [SerializeField] private float maxFallSpeed = 18f;
    [Tooltip("Increases the player fall speed")]
    [SerializeField] private float fallSpeedMultiplier = 2f;

    [Header("ScriptRef")]
    Climbing climb;

    float horizontalMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        climb = GetComponent<Climbing>();
        if(animator == null) { Debug.Log("Missing Player Animator"); }
    }

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

        animator.SetBool("Walking", false);
        animator.SetBool("Sprinting", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetBool(isSprinting ? "Sprinting" : "Walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool(isSprinting ? "Sprinting" : "Walking", true);
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
                animator.SetTrigger(animator.GetBool("Air") ? "StartDoubleJump" : "StartJump");
            }
            else if (context.canceled)
            {
                //Light tap of jump button = half the height
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                jumpsRemaining--;
                //if still nearish to ground then we've released early so small jump anim
                if (Physics2D.OverlapBox(groundCheckPos.position, smallJumpCheckSize, 0, groundLayer) || Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, grabObjectLayer)) { animator.SetTrigger("StartSmallJump"); }
            }
        }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer) || Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, grabObjectLayer))
        {
            //Grounded
            jumpsRemaining = maxJumps;

            //if was in air and have just landed, trigger endjump
            if(animator.GetBool("Air") == true) { animator.SetTrigger("EndJump"); }
            animator.SetBool("Air", false);
        }
        else
        {
            animator.SetBool("Air", true);
        }

        if (climb.isClimbing == true)
        {
            animator.SetBool("Air", false);
        }
    }

    //interacting with switches idk where else to put this code
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Switch leSwitch = collision.gameObject.GetComponent<Switch>();

        if (leSwitch != null)
        {
            leSwitch.ToggleSwitch();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPos.position, smallJumpCheckSize);
    }
}
