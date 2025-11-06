using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    private bool paused;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        paused = false;

        // gets menus
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }

    // opens pause menu
    public void OpenPauseMenu()
    {
        if (paused) return;

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // closes pause menu
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        paused = false;

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_Tower");
    }

    // takes the player back to main menu
    public void BackToMenu()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    // quits game
    public void Quit()
    {
        Application.Quit();
    }
}
