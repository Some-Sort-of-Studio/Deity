using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulers: Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
