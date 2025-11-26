using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public bool hasFired;
    public bool isActive;
    public bool isOn;

    public float spawnTimer;
    public float delayTimer;

    private void Start()
    {
        if (isOn)
        {
            On();
        }
    }

    private void SpawnObject()
    {
        Instantiate(projectile, firePoint.position, transform.rotation);
        StartCoroutine(Spawn());
    }

    public void On()
    {
        StartCoroutine(Spawn());
    }

    public void Off()
    {
        StopAllCoroutines();
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

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTimer);
        SpawnObject();
    }
}
