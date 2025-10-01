using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public bool hasFired;

    void Start()
    {
        hasFired = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasFired)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            hasFired = true;
        }
    }
}
