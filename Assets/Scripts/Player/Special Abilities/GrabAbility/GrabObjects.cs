using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement2D))]
public class GrabObjects : MonoBehaviour
{
    public Transform grabDetect;
    [SerializeField] private Vector2 grabDetectSize = new Vector2(0.5f, 0.05f);

    public Transform boxHolder;

    public LayerMask grabbableObjectLayer;

    bool objectInRange;
    bool isPickingUp;
    bool isZoomingIn;
    bool isZoomingOut;

    [Header("Distance")]
    [SerializeField] private float maxZoomSpeed;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float minDistance = 1f;
    private float distance = 1f;

    FirePoint firePoint;

    private PlayerMovement2D playerMovement;

    private void Start()
    {
        firePoint = GetComponentInChildren<FirePoint>();
        playerMovement = GetComponent<PlayerMovement2D>();
    }

    private void Update()
    {
        Collider2D grabCheck = Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer);

        if (Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer))
        {
            objectInRange = true;
        }
        else
        {
            objectInRange = false;
        }

        firePoint.SetupFiring();

        if (grabCheck != null)
        {
            if (isPickingUp)
            {
                playerMovement.enabled = false;

                grabCheck.gameObject.transform.parent = boxHolder.transform;
                grabCheck.gameObject.transform.localPosition = Vector3.zero;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().mass = 0;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
            else
            {
                playerMovement.enabled = true;

                grabCheck.gameObject.transform.parent = null;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().mass = 1;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            }
        }

        Mathf.Clamp(distance, minDistance, maxDistance);

        boxHolder.transform.position = boxHolder.transform.parent.position + boxHolder.transform.up * distance * maxZoomSpeed;
        grabDetect.transform.position = grabDetect.transform.parent.position + grabDetect.transform.right + grabDetect.transform.right * distance * maxZoomSpeed;
    }

    public void GrabAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (objectInRange)
            {
                isPickingUp = true;
            }
        }
        else if (context.canceled)
        {
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
        Gizmos.DrawWireCube(grabDetect.position, grabDetectSize);
    }

}
