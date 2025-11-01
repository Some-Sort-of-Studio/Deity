using System.Collections;
using UnityEngine;

public class WaterBlob : MonoBehaviour
{
    public Water waterSource;
    public Vector3 destPosition { set; private get; }
    public float drainAmount { set; private get; }

    private bool goingToDest;

    private void Awake()
    {
        goingToDest = true;
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
