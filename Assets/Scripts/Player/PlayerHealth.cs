using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] private int health = 5;

    [Header("Checkpoints")]
    [SerializeField] private GameObject startingCheckpoint;
    private GameObject currentCheckpoint;

    private void Awake()
    {
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

    public void Die()
    {
        health--;
        if (health <= 0)
        {
            health = 5;
            transform.position = startingCheckpoint.transform.position;
        }
        else
        {
            transform.position = currentCheckpoint.transform.position;
        }
    }
}
