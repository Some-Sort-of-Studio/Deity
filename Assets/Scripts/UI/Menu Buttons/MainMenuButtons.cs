using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        UIManager.Instance.LoadPlayerSelect();
    }

    public void QuitGame()
    {
        UIManager.Instance.Quit();
    }
}
