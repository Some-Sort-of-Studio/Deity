using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public bool hasFired;
    public bool isActive;

    public float delayTimer;

    public enum States
    {
        On,
        Off
    }

    public States state;

    private void Start()
    {
        if (state == States.On)
        {
            On();
        }

        if (state == States.Off)
        {
            Off();
        }
    }

    private void SpawnObject()
    {
        Instantiate(projectile, firePoint.position, transform.rotation);
        StartCoroutine(Delay());
    }

    public void On()
    {
        StartCoroutine(Delay());
    }

    public void Off()
    {
        StopCoroutine(Delay());
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

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTimer);
        SpawnObject();
    }
}
