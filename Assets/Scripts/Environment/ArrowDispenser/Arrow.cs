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
        if (isActive)
        {
            Invoke("SpawnObject", spawnTimer);
        }
    }

    private void SpawnObject()
    {
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        Invoke("DelayShot", delayTimer);
    }

    private void DelayShot()
    {
        Invoke("SpawnObject", spawnTimer);
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
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}
