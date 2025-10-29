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
        if(transform.position.y > (startPosition.y - transform.localScale.y))
        {
            empty = false;
            transform.position += Vector3.down * amount;
        }
        else
        {
            empty = true;
        }
    }

    public void Fill(float amount)
    {
        if (transform.position.y < startPosition.y)
        {
            full = false;
            transform.position += Vector3.up * amount;
        }
        else
        {
            full = true;
            transform.position = startPosition;
        }
    }
}
