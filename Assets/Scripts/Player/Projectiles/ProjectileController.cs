using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileController : MonoBehaviour
{
    public float speed;

    public float projectileTimer;

    WindBlast projectile;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        projectile = FindAnyObjectByType<WindBlast>();

        //if can't find references then destroy this as it won't work correctly
        if (projectile == null) { Destroy(this); Debug.Log("Missing references for " + this); }

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
