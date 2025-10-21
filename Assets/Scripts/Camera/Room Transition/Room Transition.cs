using Unity.Cinemachine;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [Header("Room Data")]
    public GameObject PrevRoom = null;
    public GameObject CurrentRoom;
    public GameObject NextRoom;

    private CinemachineBrain mainBrain;

    private void Start()
    {
        mainBrain = GetComponent<CinemachineBrain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RoomBox"))
        {
            CurrentRoom = collision.gameObject;

            if(collision.gameObject == NextRoom)
            {
                TransitionCamera(collision.gameObject);
            }

            if(PrevRoom != null && collision.gameObject == PrevRoom)
            {
                TransitionCamera(collision.gameObject);
            }

            CheckNextRoom(CurrentRoom);
        }
    }

    void TransitionCamera(GameObject room)
    {
        CinemachineCamera virtCam = room.GetComponentInChildren<CinemachineCamera>();
        virtCam.gameObject.SetActive(true);
        NextRoom = CurrentRoom;
        CurrentRoom = room;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CinemachineCamera virtCam = PrevRoom.GetComponentInChildren<CinemachineCamera>();
        virtCam.gameObject.SetActive(false);
    }

    void CheckNextRoom(GameObject room)
    {

    }
}
