using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
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

        settingsMenu = GameObject.Find("SettingsMenu");
        settingsMenu.SetActive(false);
    }

    // opens pause menu
    public void OpenPauseMenu()
    {
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

        Time.timeScale = 1f;
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // opens options menu
    public void OptionsAcitve()
    {
        settingsMenu.SetActive(true);
    }

    // closes options menu
    public void OptionsDeactive()
    {
        settingsMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_Tutorial");
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
