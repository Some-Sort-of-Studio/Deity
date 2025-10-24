using Unity.Cinemachine;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [Header("Room Data")]
    public GameObject CurrentRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentRoom.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentRoom.SetActive(false);
        }
    }
}
