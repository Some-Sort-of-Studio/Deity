using Unity.Cinemachine;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [Header("Room Data")]
    public GameObject CurrentRoom;

    private CinemachineCamera cam;

    private void Awake()
    {
        cam = CurrentRoom.GetComponent<CinemachineCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentRoom.SetActive(true);

            cam.Follow = collision.gameObject.transform;
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
