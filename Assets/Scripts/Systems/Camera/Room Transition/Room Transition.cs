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

        //if uses box set follow z offset to box height to prevent issues
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            if (boxCollider.size.y < 10)
            {
                cam.GetComponent<CinemachineFollow>().FollowOffset = Vector3.back * (boxCollider.size.y - 1);
            }

            if (boxCollider.size.x < 20)
            {
                cam.GetComponent<CinemachineFollow>().FollowOffset = Vector3.back * (boxCollider.size.x/2 - 1);
            }
        }
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
