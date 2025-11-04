using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Climbing : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float climbSpeed;

    private Rigidbody2D rb;

    private float inputVertical;

    public bool isClimbing;
    private bool ladderDetect;

    [Header("LadderCheck")]
    public Transform ladderCheck;
    [SerializeField] private Vector2 ladderCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask ladderMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        LadderCheck();
    }

    private void FixedUpdate()
    {
        inputVertical = Input.GetAxisRaw("Vertical");

        if (isClimbing && ladderDetect)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, inputVertical * climbSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
            isClimbing = false;
        }
    }

    public void ClimbUp(InputAction.CallbackContext context)
    {
        if (context.performed && ladderCheck)
        {
            isClimbing = true;
        }
    }

    public void ClimbDown(InputAction.CallbackContext context)
    {
        if (context.performed && ladderCheck)
        {
            isClimbing = true;
        }
    }

    private void LadderCheck()
    {
        if (Physics2D.OverlapBox(ladderCheck.position, ladderCheckSize, 0, ladderMask))
        {
            ladderDetect = true;
        }
        else
        {
            ladderDetect = false;
        }
    }
}
