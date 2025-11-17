using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed;

    public float projectileTimer;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);

        Invoke("DestroyObject", projectileTimer);
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }
}
