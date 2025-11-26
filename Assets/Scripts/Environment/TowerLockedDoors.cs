using UnityEngine;

public class TowerLockedDoors : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
        }
    }
}
