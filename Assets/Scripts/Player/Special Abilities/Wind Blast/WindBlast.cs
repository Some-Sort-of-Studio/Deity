using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindBlast : MonoBehaviour
{
    public FirePoint firePoint;
    public GameObject projectile;

    public bool hasFired;

    private AudioSource audioSource;

    void Start()
    {
        //if can't find references then destroy this as it won't work correctly
        if (firePoint == null || projectile == null) { Destroy(this); Debug.Log("Missing references for " + this); }

        hasFired = false;
        audioSource = projectile.GetComponent<AudioSource>();
    }

    public void WindBlastAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firePoint.SetupFiring();
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            AudioManager.Instance.PlayAudio("Wind_Shot" , audioSource);
            hasFired = true;
        }
    }
}
