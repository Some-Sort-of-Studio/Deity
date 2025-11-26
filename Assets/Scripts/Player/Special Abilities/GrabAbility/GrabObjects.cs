using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement2D))]
public class GrabObjects : MonoBehaviour
{
    public bool grabObjectsEnabled = true;

    public Transform boxHolder;
    [SerializeField] private Vector2 grabDetectSize = new Vector2(1.5f, 0.05f);

    public LayerMask grabbableObjectLayer;

    [HideInInspector] public bool isTryingGrab;
    [HideInInspector] public bool isPickingUp;
    private GameObject pickupObject;
    private MoveableObjectLimit pickupObjectLimiter;

    [Header("Distance")]
    [SerializeField] private float maxZoomSpeed;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float minDistance = 1f;
    const float defaultDistance = 1.5f;
    private float distance = 1.5f;

    GrabPoint grabPoint;

    private PlayerMovement2D playerMovement;

    private void Start()
    {
        grabPoint = GetComponentInChildren<GrabPoint>();
        playerMovement = GetComponent<PlayerMovement2D>();
    }

    private void Update()
    {
        if (!grabObjectsEnabled) return;

        if (isTryingGrab)
        {
            grabPoint.SetupGrabbing();
        }
        if (isPickingUp)
        {
            if (pickupObjectLimiter.outsideMaxDistance) { DropObject(); }
            pickupObject.transform.localPosition = Vector3.zero;

            Mathf.Clamp(distance, minDistance, maxDistance);

            boxHolder.transform.position = boxHolder.transform.parent.position + boxHolder.transform.up * distance * maxZoomSpeed;
        }
    }

    public void GrabAbility(InputAction.CallbackContext context)
    {
        grabPoint.SetupGrabbing();
        Collider2D grabCheck = Physics2D.OverlapBox(boxHolder.position, grabDetectSize, 0, grabbableObjectLayer);

        if (context.performed)
        {
            isTryingGrab = true;
            if (grabCheck != null)
            {
                isPickingUp = true;
                pickupObject = grabCheck.gameObject;
                pickupObjectLimiter = pickupObject.GetComponent<MoveableObjectLimit>();

                //playerMovement.movementEnabled = false;

                pickupObject.transform.parent = boxHolder.transform;
                pickupObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                pickupObject.GetComponent<Rigidbody2D>().mass = 0;
                pickupObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
        }
        else if (context.canceled)
        {
            DropObject();
        }
    }

    public void DropObject()
    {
        isTryingGrab = false;
        if (isPickingUp)
        {
            //playerMovement.movementEnabled = true;

            pickupObject.transform.parent = null;
            pickupObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            pickupObject.GetComponent<Rigidbody2D>().mass = 1000;
            pickupObject.GetComponent<Rigidbody2D>().freezeRotation = false;

            //reset box holder position
            distance = defaultDistance;
            boxHolder.transform.position = boxHolder.transform.parent.position + boxHolder.transform.up * distance * maxZoomSpeed;

            //remove references and not longer ispickingup
            pickupObject = null;
            isPickingUp = false;
        }
    }


    public void ZoomIn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(distance > minDistance)
            {
                distance--;
            }
        }
    }

    public void ZoomOut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (distance < maxDistance)
            {
                distance++;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(boxHolder.position, grabDetectSize);
    }

}
