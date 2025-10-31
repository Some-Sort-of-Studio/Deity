using System.Collections;
using UnityEngine;

public class WaterBlob : MonoBehaviour
{
    public Water waterSource;
    public Vector3 destPosition { set; private get; }
    public float drainAmount { set; private get; }

    [SerializeField] private float lifetime = 10;
    private bool goingToDest;

    private void Awake()
    {
        goingToDest = true;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (goingToDest)
        {
            transform.position = Vector3.Lerp(transform.position, destPosition, 0.01f);

            if (Vector3.Distance(transform.position, destPosition) < 0.1f)
            {
                goingToDest = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * 0.0005f);
        }
    }

    private void OnDestroy()
    {
        waterSource.Fill(drainAmount);
    }
}
