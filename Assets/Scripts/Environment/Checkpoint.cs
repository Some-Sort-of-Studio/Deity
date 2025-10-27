using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public enum CheckpointType
    {
        CheckPoint,
        StartingPoint
    }

    [SerializeField] private CheckpointType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            switch (type)
            {
                case CheckpointType.StartingPoint:
                    playerHealth.Startingpoint(gameObject);
                    break;
                case CheckpointType.CheckPoint:
                    playerHealth.Checkpoint(gameObject);
                    break;
            }
        }
    }
}
