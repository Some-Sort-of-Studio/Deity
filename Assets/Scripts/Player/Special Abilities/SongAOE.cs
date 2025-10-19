using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SongAOE : MonoBehaviour
{
    public GameObject AOE;

    void Start()
    {
        AOE.SetActive(false);
    }

    public void SongAOEAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AOE.SetActive(true);
        }
        else if(context.canceled)
        {
            AOE.SetActive(false);
        }
    }
}
