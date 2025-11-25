using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject playerObject;

    [SerializeField] private GameObject pauseMenu;
    [HideInInspector] public bool paused;

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

        //for test scenes v
        Scene scene = SceneManager.GetActiveScene();
        if(scene.handle != SceneManager.sceneCountInBuildSettings)
        {
            FindPauseMenu();
            FindPlayerObject();
        }
    }

    private void FindPauseMenu()
    {
        //get pause menu
        pauseMenu = GameObject.FindFirstObjectByType<PauseMenuButtons>().gameObject;
        ClosePauseMenu();
    }

    private void FindPlayerObject()
    {
        //try get player
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void TogglePlayerAbilities(bool abilityEnabled)
    {
        //try find player if not got a reference
        if (playerObject == null) { FindPlayerObject(); }

        //if player reference then toggle all potential abilities
        if (playerObject != null)
        {
            playerObject.GetComponent<PlayerMovement2D>().enabled = abilityEnabled;

            Climbing climbing = playerObject.GetComponent<Climbing>();
            if (climbing != null) { climbing.enabled = abilityEnabled; }

            WindBlast windBlast = playerObject.GetComponent<WindBlast>();
            if (windBlast != null) { windBlast.enabled = abilityEnabled; }

            SongAOE songAOE = playerObject.GetComponent<SongAOE>();
            if (songAOE != null) { songAOE.enabled = abilityEnabled; }

            ManipulateWater manipulateWater = playerObject.GetComponent<ManipulateWater>();
            if (manipulateWater != null) { manipulateWater.enabled = abilityEnabled; }

            GrabObjects grabObjects = playerObject.GetComponent<GrabObjects>();
            if (grabObjects != null) { grabObjects.enabled = abilityEnabled; }
        }
    }


    // opens pause menu
    public void OpenPauseMenu()
    {
        if (paused) return;

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

        TogglePlayerAbilities(false);
    }

    // closes pause menu
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        paused = false;

        Time.timeScale = 1f;

        TogglePlayerAbilities(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_Tower");
        SceneManager.UnloadSceneAsync("Character Selection");

        if (pauseMenu == null) { Invoke(nameof(FindPauseMenu), 0.2f); } 
        if (playerObject == null) { Invoke(nameof(FindPlayerObject), 0.2f); }
    }

    public void LoadPlayerSelect()
    {
        SceneManager.LoadScene("Character Selection");
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
