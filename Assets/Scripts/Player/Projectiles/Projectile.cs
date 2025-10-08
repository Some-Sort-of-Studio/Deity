using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public FirePoint firePoint;
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
            firePoint.SetupFiring();
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            hasFired = true;
        }
    }
}
