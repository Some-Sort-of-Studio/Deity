using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTestLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("player ability testing scene");
        }
    }
}
