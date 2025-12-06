using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    const int maxHealth = 5;

    private Animator animator;

    [Header("Lives")]
    private bool dying;
    [SerializeField] private int health = maxHealth;

    [Header("Checkpoints")]
    [SerializeField] private GameObject startingCheckpoint;
    private GameObject currentCheckpoint;

    [Header("Teleportation")]
    private bool teleporting;
    [SerializeField] private float teleportToStartTime = 1;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private float deathTime;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        dying = false;
        teleporting = false;

        if (startingCheckpoint == null) { Debug.Log("Missing player start checkpoint"); }
        else { currentCheckpoint = startingCheckpoint; }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void Checkpoint(GameObject checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void Startingpoint(GameObject checkpoint)
    {
        startingCheckpoint = checkpoint;
        currentCheckpoint = checkpoint;
    }

    public void TeleportToStart(InputAction.CallbackContext context)
    {
        if (!teleporting && context.performed)
        {
            teleporting = true;
            animator.SetBool("TeleportToStart", true);
            StartCoroutine(nameof(Teleporting));
        }

        if (context.canceled)
        {
            teleporting = false;
            animator.SetBool("TeleportToStart", false);
        }
    }

    private IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(teleportToStartTime);
        if (teleporting) //if still teleporting after the time
        {
            health = maxHealth;
            healthSlider.value = health;
            transform.position = startingCheckpoint.transform.position;

            teleporting = false;
            animator.SetBool("TeleportToStart", false);
        }
    }

    public IEnumerator Die()
    {
        if (!dying)
        {
            dying = true;
            Debug.Log("Died");

            health--;
            GameObject deathCanvasInstance = Instantiate(deathCanvas, null);

            yield return new WaitForSeconds(deathTime / 2);

            if (health <= 0)
            {
                health = maxHealth;
                transform.position = startingCheckpoint.transform.position;
            }
            else
            {
                transform.position = currentCheckpoint.transform.position;
            }

            healthSlider.value = health;
            yield return new WaitForSeconds(deathTime / 2);

            Destroy(deathCanvasInstance);

            dying = false;
        }
    }
}
