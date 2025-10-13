using UnityEngine;

public class Scripture : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
