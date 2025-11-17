using UnityEngine;

public class ArrowEvents : MonoBehaviour
{
    private ArrowMovement movement;

    private void Awake()
    {
        movement  = GetComponent<ArrowMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SongAOE"))
        {
            movement.DestoryObject();
        }
    }
}
