using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement2D))]
public class GrabObjects : MonoBehaviour
{
    public Transform grabDetect;
    [SerializeField] private Vector2 grabDetectSize = new Vector2(2.5f, 0.05f);

    public Transform boxHolder;

    public LayerMask grabbableObjectLayer;

    [HideInInspector] public bool isPickingUp;
    private GameObject pickupObject;

    [Header("Distance")]
    [SerializeField] private float maxZoomSpeed;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float minDistance = 1f;
    const float defaultDistance = 1.5f;
    private float distance = 1.5f;

    FirePoint firePoint;

    private PlayerMovement2D playerMovement;

    private void Start()
    {
        firePoint = GetComponentInChildren<FirePoint>();
        playerMovement = GetComponent<PlayerMovement2D>();
    }

    private void Update()
    {
        if (isPickingUp)
        {
            firePoint.SetupFiring();
            pickupObject.transform.localPosition = Vector3.zero;

            Mathf.Clamp(distance, minDistance, maxDistance);

            boxHolder.transform.position = boxHolder.transform.parent.position + boxHolder.transform.up * distance * maxZoomSpeed;
            grabDetect.transform.position = grabDetect.transform.parent.position + grabDetect.transform.right + grabDetect.transform.right * distance * maxZoomSpeed;
        }
    }

    public void GrabAbility(InputAction.CallbackContext context)
    {
        Collider2D grabCheck = Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer);

        if (context.performed)
        {
            if (grabCheck != null)
            {
                isPickingUp = true;
                pickupObject = grabCheck.gameObject;

                playerMovement.movementEnabled = false;

                pickupObject.transform.parent = boxHolder.transform;
                pickupObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                pickupObject.GetComponent<Rigidbody2D>().mass = 0;
                pickupObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
        }
        else if (context.canceled)
        {
            if (isPickingUp)
            {
                playerMovement.movementEnabled = true;

                pickupObject.transform.parent = null;
                pickupObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                pickupObject.GetComponent<Rigidbody2D>().mass = 1;
                pickupObject.GetComponent<Rigidbody2D>().freezeRotation = false;

                //reset box holder position
                distance = defaultDistance;
                boxHolder.transform.position = boxHolder.transform.parent.position + boxHolder.transform.up * distance * maxZoomSpeed;
                grabDetect.transform.position = grabDetect.transform.parent.position + grabDetect.transform.right + grabDetect.transform.right * distance * maxZoomSpeed;

                //remove references and not longer ispickingup
                pickupObject = null;
                isPickingUp = false;
            }
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
        Gizmos.DrawWireCube(grabDetect.position, grabDetectSize);
    }

}
