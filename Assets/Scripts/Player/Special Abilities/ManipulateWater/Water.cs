using UnityEngine;

public class Water : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector] public bool empty;
    [HideInInspector] public bool full;

    private Vector3 originalScale;

    private void Awake()
    {
        startPosition = transform.position;

        empty = false;
        full = true;

        originalScale = transform.localScale;
    }

    public void Drain(float amount)
    {
        transform.position += Vector3.down * amount/2;
        transform.localScale += Vector3.down * amount;

        full = false;
        empty = transform.position.y <= (startPosition.y - originalScale.y/2);
    }

    public void Fill(float amount)
    {
        transform.position += Vector3.up * amount/2;
        transform.localScale += Vector3.up * amount;

        empty = false;
        if (transform.position.y < startPosition.y) { full = false; }
        else
        {
            full = true;
            transform.position = startPosition;
        }
    }
}
