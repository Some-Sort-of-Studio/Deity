using UnityEngine;

public class Water : MonoBehaviour
{
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public void Drain(float amount)
    {
        if(transform.position.y > (startPosition.y - transform.localScale.y))
        {
            transform.position += Vector3.down * amount;
        }
        Debug.Log(startPosition.y - transform.localScale.y);
    }

    public void Fill(float amount)
    {
        if (transform.position.y < startPosition.y)
        {
            transform.position += Vector3.up * amount;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
