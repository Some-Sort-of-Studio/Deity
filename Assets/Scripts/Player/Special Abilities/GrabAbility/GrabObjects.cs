using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    public Transform grabDetect;
    [SerializeField] private Vector2 grabDetectSize = new Vector2(0.5f, 0.05f);
    public Transform boxHolder;
    public GameObject boxHolderObject;

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
    public GameObject firePointObject;

    private void Start()
    {
        firePoint = firePointObject.GetComponent<FirePoint>();
    }

    private void Update()
    {
        Collider2D grabCheck = Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer);

        firePoint.SetupFiring();

        if (Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer))
        {
            objectInRange = true;

            if (isPickingUp)
            {
                grabCheck.gameObject.transform.parent = boxHolder;
                grabCheck.gameObject.transform.position = boxHolder.position;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().mass = 0;
            }
            else
            {
                grabCheck.gameObject.transform.parent = null;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().mass = 1;
            }
        }
        else
        {
            objectInRange = false;
        }

        Mathf.Clamp(distance, minDistance, maxDistance);

        if (isZoomingIn && distance > minDistance)
        {
            Vector2 boxHolderNormalizedDirection = (boxHolder.transform.position - this.gameObject.transform.position).normalized;
            Vector2 grabDetectNormalizedDirection = (grabDetect.transform.position - this.gameObject.transform.position).normalized;

            boxHolder.transform.Translate(-boxHolderNormalizedDirection * maxZoomSpeed);
            grabDetect.transform.Translate(-grabDetectNormalizedDirection * maxZoomSpeed);

            distance--;
        }

        if (isZoomingOut && distance < maxDistance)
        {
            Vector2 BoxHolderNormalizedDirection = (boxHolder.transform.position - this.gameObject.transform.position).normalized;
            Vector2 grabDetectNormalizedDirection = (grabDetect.transform.position - this.gameObject.transform.position).normalized;

            boxHolder.transform.Translate(BoxHolderNormalizedDirection * maxZoomSpeed);
            grabDetect.transform.Translate(grabDetectNormalizedDirection * maxZoomSpeed);

            distance++;
        }
    }

    public void GrabAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPickingUp = true;
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
            isZoomingIn = true;
        }
        else if (context.canceled)
        {
            isZoomingIn = false;
        }
    }

    public void ZoomOut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isZoomingOut = true;
        }
        else if (context.canceled)
        {
            isZoomingOut = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(grabDetect.position, grabDetectSize);
    }

}
