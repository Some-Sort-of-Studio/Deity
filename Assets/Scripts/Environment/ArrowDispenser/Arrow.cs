using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject projectile;

    public bool hasFired;
    public bool isActive;

    public float spawnTimer;
    public float delayTimer;

    public enum States
    {
        On,
        Off
    }

    public States state;

    public void Update()
    {
        if (!hasFired && isActive)
        {
            Invoke("SpawnObject", spawnTimer);
            hasFired = true;
        }
    }

    private void SpawnObject()
    {
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        hasFired = false;
        Invoke("DelayShot", delayTimer);
    }

    private void DelayShot()
    {
        if (!hasFired && isActive)
        {
            Invoke("SpawnObject", spawnTimer);
        }
    }

    public void On()
    {
        isActive = true;
    }

    public void Off()
    {
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Off();
        }
    }
}
