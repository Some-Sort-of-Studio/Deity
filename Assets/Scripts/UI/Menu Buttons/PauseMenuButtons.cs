using UnityEngine;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject OptionsMenu;

    public void Resume()
    {
        UIManager.Instance.ClosePauseMenu();
    }

    public void BackToMenu()
    {
        UIManager.Instance.BackToMenu();
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
