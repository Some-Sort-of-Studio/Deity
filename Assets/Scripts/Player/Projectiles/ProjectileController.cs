using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileController : MonoBehaviour
{
    public float speed;

    public float projectileTimer;

    public PlayerMovement playerScript;
    Projectile projectile;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = FindAnyObjectByType<PlayerMovement>();
        projectile = FindAnyObjectByType<Projectile>();

        //if can't find script references then destroy this as it won't work correctly
        if (playerScript == null || projectile == null) { Destroy(this); }

        if (playerScript.transform.localScale.x < 0)
        {
            speed = -speed;
        }

        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

        Invoke("DestroyObject", projectileTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        projectile.hasFired = false;
        Destroy(gameObject);
    }
}
