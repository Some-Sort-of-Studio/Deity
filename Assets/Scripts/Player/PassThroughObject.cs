using UnityEngine;

public class PassThroughObject : MonoBehaviour
{
    [Header("LayerMasks")]
    public LayerMask whatIsPassableMask;
    public bool passableObject;

    public GameObject playerObj;
    Rigidbody rb;
    CapsuleCollider cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = playerObj.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        passableObject = Physics.Raycast(transform.position, Vector3.right, whatIsPassableMask);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (passableObject)
        {
            rb.isKinematic = true;
            cc.isTrigger = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.useGravity = true;
        cc.isTrigger = true;
    }
}
