using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    public float projectileTimer;

    public PlayerMovement playerScript;

    Projectile projectile;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerScript = FindAnyObjectByType<PlayerMovement>();
        projectile = FindAnyObjectByType<Projectile>();

        if (playerScript.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    void Update()
    {
        rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y);

        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        projectile.hasFired = false;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(projectileTimer);
        Destroy(gameObject);
    }
}
