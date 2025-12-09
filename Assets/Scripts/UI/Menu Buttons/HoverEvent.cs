using UnityEngine;

public class HoverEvent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool selected;

    public void Hover()
    {
        if(!selected) animator.SetBool("Hovering", true);
    }

    public void UnHover()
    {
        if (!selected) animator.SetBool("Hovering", false);
    }

    public void Selected()
    {
        if(!selected)
        {
            animator.SetBool("Selected", true);
            animator.SetBool("Hovering", true);
            selected = true;
        }
    }

    public void UnSelected()
    {
        if (selected)
        {
            animator.SetBool("Selected", false);
            animator.SetBool("Hovering", false);
            selected = false;
        }
    }
}
