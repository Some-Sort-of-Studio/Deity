using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject OptionsMenu;

    public void StartGame()
    {
        UIManager.Instance.LoadPlayerSelect();
    }

    public void QuitGame()
    {
        UIManager.Instance.Quit();
    }

    public void OnSelected()
    {
        animator.SetBool("Selected", true);
    }

    public void OpenOptions()
    {
        OptionsMenu.SetActive(true);
        animator.SetBool("MenuOpen", true);
    }

    public void PlayCloseAnim()
    {
        animator.SetBool("MenuOpen", false);
        Invoke(nameof(CloseOptions), 0.5f);
    }

    private void CloseOptions()
    {
        OptionsMenu.SetActive(false);
    }
}
