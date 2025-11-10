using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuPlayerInput : MonoBehaviour
{
    public void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (UIManager.Instance.paused)
            {
                UIManager.Instance.ClosePauseMenu();
            }
            else
            {
                UIManager.Instance.OpenPauseMenu();
            }
        }
    }
}
