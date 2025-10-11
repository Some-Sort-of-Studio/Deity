using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private float breakAnimationTime = 0f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(animator == null) { breakAnimationTime = 0f; } //if not found animator then no break animation to wait for
    }

    public void BreakObject()
    {
        if(animator != null)
        {
            animator.SetTrigger("Break");
        }

        Destroy(gameObject, breakAnimationTime);
    }
}
