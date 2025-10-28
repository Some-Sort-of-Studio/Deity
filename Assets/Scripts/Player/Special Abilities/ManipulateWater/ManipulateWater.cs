using UnityEngine;
using UnityEngine.InputSystem;

public class ManipulateWater : MonoBehaviour
{
    [SerializeField]

    public void ManipulateWaterAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Water water = FindNearestObject.FindNearestObjectByType<Water>(transform.position, FindObjectsByType<Water>(0));

            if(context.duration % 2 == 0)
            {
                PaintWater();
            }
        }
    }

    private void PaintWater()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);


    }
}
