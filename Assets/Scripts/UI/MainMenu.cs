using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayerScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
