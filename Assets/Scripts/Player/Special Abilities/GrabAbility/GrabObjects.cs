using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    public Transform grabDetect;
    [SerializeField] private Vector2 grabDetectSize = new Vector2(0.5f, 0.05f);
    public Transform boxHolder;
    public float rayDist;

    public LayerMask grabbableObjectLayer;

    public bool objectInRange;
    bool isPickingUp;

    private void Update()
    {
        Collider2D grabCheck = Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer);

        if (Physics2D.OverlapBox(grabDetect.position, grabDetectSize, 0, grabbableObjectLayer))
        {
            objectInRange = true;

            if (isPickingUp)
            {
                grabCheck.gameObject.transform.parent = boxHolder;
                grabCheck.gameObject.transform.position = boxHolder.position;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else
            {
                grabCheck.gameObject.transform.parent = null;
                grabCheck.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else
        {
            objectInRange = false;
        }
    }

    public void GrabAbility(InputAction.CallbackContext context)
    {
            if (context.performed && objectInRange)
            {
            isPickingUp = true;
            }
            else if (context.canceled)
            {
            isPickingUp = false;
            }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(grabDetect.position, grabDetectSize);
    }

}
