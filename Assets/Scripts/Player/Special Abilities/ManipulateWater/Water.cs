using UnityEngine;

public class Water : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector] public bool empty;
    [HideInInspector] public bool full;

    private void Awake()
    {
        startPosition = transform.position;

        empty = false;
        full = true;
    }

    public void Drain(float amount)
    {
        transform.position += Vector3.down * amount;

        full = false;
        empty = transform.position.y <= (startPosition.y - transform.localScale.y);
    }

    public void Fill(float amount)
    {
        transform.position += Vector3.up * amount;

        empty = false;
        if (transform.position.y < startPosition.y) { full = false; }
        else
        {
            full = true;
            transform.position = startPosition;
        }
    }
}
