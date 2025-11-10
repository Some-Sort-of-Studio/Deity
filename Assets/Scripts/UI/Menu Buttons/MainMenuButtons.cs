using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        UIManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        UIManager.Instance.Quit();
    }
}
