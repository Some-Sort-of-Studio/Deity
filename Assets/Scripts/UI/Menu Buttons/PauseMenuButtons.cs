using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    public void Resume()
    {
        UIManager.Instance.ClosePauseMenu();
    }

    public void BackToMenu()
    {
        UIManager.Instance.BackToMenu();
    }

    public void QuitGame()
    {
        UIManager.Instance.Quit();
    }
}
