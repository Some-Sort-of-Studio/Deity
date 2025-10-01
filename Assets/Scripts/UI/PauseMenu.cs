using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuCanvas;

    public bool isOptionsMenuActive;

    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOptionsMenuActive)
        {
            if (paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);

        Time.timeScale = 0f;
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);

        Time.timeScale = 1f;
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OptionsAcitve()
    {
        isOptionsMenuActive = true;
    }

    public void OptionsDeactive()
    {
        isOptionsMenuActive = false;
    }

    public void BackToMenu()
    {
        pauseMenuCanvas.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
