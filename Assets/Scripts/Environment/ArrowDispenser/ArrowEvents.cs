using UnityEngine;

public class ArrowEvents : MonoBehaviour
{
    private ArrowMovement movement;

    private void Awake()
    {
        movement = GetComponentInParent<ArrowMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SongAOE"))
        {
            movement.DestoryObject();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            movement.DestoryObject();
        }
    }
}
