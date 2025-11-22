using UnityEngine;

public class InteractableProp : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float killTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Interact");
        if(killTime > 0) { Destroy(gameObject, killTime); }
    }
}
