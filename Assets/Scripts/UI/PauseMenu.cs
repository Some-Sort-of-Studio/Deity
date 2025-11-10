using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private bool isPauseMenuOpen;
    private bool isPauseMenuClose;

    public void Start()
    {
        isPauseMenuOpen = false;
        isPauseMenuClose = true;
    }

    public void OpenPauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed && isPauseMenuClose)
        {
            UIManager.Instance.OpenPauseMenu();
            isPauseMenuClose = false;
            isPauseMenuOpen = true;
        }
    }

    public void ClosePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed && isPauseMenuOpen)
        {
            UIManager.Instance.ClosePauseMenu();
            isPauseMenuOpen = false;
            isPauseMenuClose = true;
        }
    }
}
