using UnityEngine;

public class MoveableObjectLimit : MonoBehaviour
{
    [HideInInspector] public bool outsideMaxDistance;

    [SerializeField] private float maxDistance = 8;
    Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        outsideMaxDistance = false;
    }

    private void FixedUpdate()
    {
        if (transform.position != startPosition)
        {
            if (Vector3.Distance(transform.position, startPosition) > maxDistance)
            {
                outsideMaxDistance = true;
                Invoke(nameof(ResetPosition), 1f);
            }
            else
            {
                outsideMaxDistance = false;
            }
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }
}
