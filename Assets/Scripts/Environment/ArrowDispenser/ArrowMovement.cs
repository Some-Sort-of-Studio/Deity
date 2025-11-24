using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }
}
