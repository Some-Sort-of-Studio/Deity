using UnityEngine;

public class DieOnSpawn : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
