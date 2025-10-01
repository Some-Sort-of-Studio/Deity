using UnityEngine;

public class Climbing : MonoBehaviour
{
    private float vertical;
    private float speed = 2;
    private bool isClimable;
    private bool isClimbing;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.useGravity = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, vertical * speed);
        }
        else
        {
            rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClimableObject"))
        {
            isClimable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ClimableObject"))
        {
            isClimable = false;
            isClimbing = false;
        }
    }
}
