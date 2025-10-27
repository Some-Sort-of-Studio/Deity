using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string StartingLevel;

    public void PlayGame()
    {
        SceneManager.LoadScene(StartingLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
