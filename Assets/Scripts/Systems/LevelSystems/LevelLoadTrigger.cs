using UnityEngine;
using UnityEngine.SceneManagement;

// THIS IS TEMP AND TAKEN FROM A GUIDE WHILE I DESIGN A SCENE LOADER
// credit to https://www.youtube.com/watch?v=6-0zD9Xyu5c (Sasquach B Studios) //TODO:: IMPROVE AND MAKE MY OWN!!!
public class LevelLoadTrigger : MonoBehaviour
{
    [SerializeField] private string[] scenesToLoad;
    [SerializeField] private string[] scenesToUnLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneLoader();
            SceneUnloader();
        }
    }

    // loads a scene from the scenetoload array and the scenemanager count
    private void SceneLoader()
    {
        for(int i = 0; i < scenesToLoad.Length; i++)
        {
            bool isSceneLoaded = false;
            for(int  j = 0; j < SceneManager.sceneCount; j++)
            {
                // checks if the scene is already loaded
                Scene sceneLoaded = SceneManager.GetSceneAt(j);
                if(sceneLoaded.name == scenesToLoad[i])
                {
                    isSceneLoaded = true;
                    break;
                }
            }

            // loads the scene required
            if(!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            }
        }
    }

    // unloads a scene if needed for performance
    private void SceneUnloader()
    {
        for (int i = 0; i < scenesToUnLoad.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene sceneLoaded = SceneManager.GetSceneAt(j);
                if (sceneLoaded.name == scenesToLoad[i])
                {
                    SceneManager.UnloadSceneAsync(scenesToUnLoad[i]);
                }
            }
        }
    }
}
