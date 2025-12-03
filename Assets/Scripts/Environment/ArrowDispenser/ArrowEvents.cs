using UnityEngine;
using System.Collections;

public class ArrowEvents : MonoBehaviour
{
    private ArrowMovement movement;
    public float destroyTimer;

    private void Awake()
    {
        movement = GetComponentInParent<ArrowMovement>();
        StartCoroutine(DestoryObject());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            movement.DestoryObject();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player"))
        {
            movement.DestoryObject();
        }
    }

    private IEnumerator DestoryObject()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
}
