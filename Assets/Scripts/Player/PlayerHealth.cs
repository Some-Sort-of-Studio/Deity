using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool dying;

    [Header("Lives")]
    [SerializeField] private int health = 5;

    [Header("Checkpoints")]
    [SerializeField] private GameObject startingCheckpoint;
    private GameObject currentCheckpoint;

    [Header("UI")]
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private float deathTime;

    private void Awake()
    {
        dying = false;

        if (startingCheckpoint == null) { Debug.Log("Missing player start checkpoint"); }
        else { currentCheckpoint = startingCheckpoint; }
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
                health = 5;
                transform.position = startingCheckpoint.transform.position;
            }
            else
            {
                transform.position = currentCheckpoint.transform.position;
            }

            yield return new WaitForSeconds(deathTime / 2);

            Destroy(deathCanvasInstance);

            dying = false;
        }
    }
}
