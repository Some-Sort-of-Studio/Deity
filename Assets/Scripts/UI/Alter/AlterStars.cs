using UnityEngine;

public class AlterStars : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Tome tome;
    public void CheckforTome(GameObject player)
    {
        if(player.GetComponent<PlayerInventory>().CheckInventory(tome))
        {
            animator.SetTrigger(tome.TomeName);
        }
    }

    public void StopAnim()
    {
        animator.SetTrigger(tome.TomeName);
    }
}
