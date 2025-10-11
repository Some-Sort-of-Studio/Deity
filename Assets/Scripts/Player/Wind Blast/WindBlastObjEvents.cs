using UnityEngine;

[RequireComponent (typeof(WindBlastObjMovement))]
public class WindBlastObjEvents : MonoBehaviour
{
    private WindBlastObjMovement objMovement;

    private void Awake()
    {
        objMovement = GetComponent<WindBlastObjMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BreakableObject breakableObject = collision.gameObject.GetComponent<BreakableObject>();

        if (breakableObject != null)
        {
            breakableObject.BreakObject();
        }

        Switch leSwitch = collision.gameObject.GetComponent<Switch>();

        if (leSwitch != null)
        {
            leSwitch.ToggleSwitch();
        }

        //if hit something that isnt player then destroy self
        if (!collision.gameObject.CompareTag("Player"))
        {
            objMovement.DestroyObject();
        }
    }
}
