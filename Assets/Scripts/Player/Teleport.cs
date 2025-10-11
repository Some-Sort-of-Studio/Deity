using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private bool playerOverlapping;
    private GameObject playerObject;

    [SerializeField] private KeyCode interactKey = KeyCode.W;
    [SerializeField] private GameObject objectToTeleportTo;
    [SerializeField] private float teleportAnimationTime = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(interactKey == 0) { Debug.Log("Missing keybind for " + this); }
        if(objectToTeleportTo == null) { Debug.Log("Missing references for " + this); }
    }

    private void Update()
    {
        if (Input.GetKeyUp(interactKey) && playerOverlapping)
        {
            Invoke("Teleport", teleportAnimationTime);
        }
    }

    private void Teleport()
    {
        Debug.Log(playerObject.transform.position);
        playerObject.transform.position = objectToTeleportTo.transform.position;
        playerOverlapping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerObject = collision.gameObject;
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOverlapping = false;
        }
    }
}
