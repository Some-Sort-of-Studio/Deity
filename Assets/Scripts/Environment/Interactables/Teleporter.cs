using AudioSystem;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private bool playerOverlapping;
    private GameObject playerObject;
    private Animator playerAnimator;

    [SerializeField] private KeyCode interactKey = KeyCode.W;
    [SerializeField] private GameObject objectToTeleportTo;
    [SerializeField] private float teleportAnimationTime = 0.5f;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(interactKey == 0) { Debug.Log("Missing keybind for " + this); }
        if(objectToTeleportTo == null) { Debug.Log("Missing references for " + this); }
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(interactKey) && playerOverlapping)
        {
            playerAnimator.SetBool("Door", true);
            Invoke("Teleport", teleportAnimationTime);
            AudioManager.Instance.PlayAudio("Door", audioSource);
        }
    }

    private void Teleport()
    {
        playerAnimator.SetBool("Door", false);
        playerObject.transform.position = objectToTeleportTo.transform.position;
        playerOverlapping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerObject = collision.gameObject;
            playerAnimator = playerObject.GetComponentInChildren<Animator>();
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
