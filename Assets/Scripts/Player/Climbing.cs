using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Climbing : MonoBehaviour
{
    public bool climbingEnabled = true;

    [SerializeField] private float distance;
    [SerializeField] private float climbSpeed;

    private Rigidbody2D rb;

    private float inputVertical;

    public bool isClimbing;
    public bool ladderDetect;
    public bool tryingToClimbDown;
    private GameObject TopOfLadder;

    [Header("LadderCheck")]
    public Transform ladderCheck;
    [SerializeField] private Vector2 ladderCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask ladderMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isClimbing = false;
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
        if(!climbingEnabled) return;

        if (context.performed && ladderDetect)
        {
            isClimbing = true;
        }
    }

    public void ClimbDown(InputAction.CallbackContext context)
    {
        if (!climbingEnabled) return;

        if (context.performed)
        {
            tryingToClimbDown = true;
        }
        
        if (context.performed && ladderDetect)
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (tryingToClimbDown && collision.gameObject.CompareTag("TopOfLadder"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopOfLadder"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
