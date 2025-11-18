using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject projectile;

    private bool hasFired;

    public float spawnTimer;

    public void Update()
    {
        if (!hasFired)
        {
            Invoke("SpawnObject", spawnTimer);
            hasFired = true;
        }
    }

    private void SpawnObject()
    {
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        hasFired = false;
    }
}
