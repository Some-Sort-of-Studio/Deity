using UnityEngine;

public class WaterBlob : MonoBehaviour
{
    public Water waterSource;

    public Vector3 destPosition { set; private get; }
    public float drainAmount { set; private get; }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destPosition, 0.01f);
    }
}
