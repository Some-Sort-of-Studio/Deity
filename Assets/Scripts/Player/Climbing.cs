using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Climbing : MonoBehaviour
{
    private float vertical;
    private float speed = 2;
    private bool isClimable;
    private bool isClimbing;

    private Rigidbody2D rb;
    [SerializeField] private float gravity = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isClimable && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = gravity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ClimableObject"))
        {
            isClimable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ClimableObject"))
        {
            isClimable = false;
            isClimbing = false;
        }
    }
}
