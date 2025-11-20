using UnityEngine;

[RequireComponent (typeof(Animator))]
public class DrowningAnimator : MonoBehaviour //this script exists so that the drowning animation resets when this object is set to active again
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator> ();
    }

    private void OnEnable()
    {
        animator.SetTrigger("Enabled");
    }
}
