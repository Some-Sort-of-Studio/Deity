using UnityEngine;

public class TempKillBox : MonoBehaviour
{
    public GameObject GO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GO.SetActive(false);
        }
    }
}
