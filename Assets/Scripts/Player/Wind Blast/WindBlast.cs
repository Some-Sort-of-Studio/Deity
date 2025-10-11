using Unity.VisualScripting;
using UnityEngine;

public class WindBlast : MonoBehaviour
{
    public FirePoint firePoint;
    public GameObject projectile;

    public bool hasFired;

    void Start()
    {
        //if can't find references then destroy this as it won't work correctly
        if (firePoint == null || projectile == null) { Destroy(this); Debug.Log("Missing references for " + this); }

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
