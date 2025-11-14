using UnityEngine;

public class FirePoint : GrabPoint
{
    //to run just before a projectile is instantiated
    public void SetupFiring()
    {
        SetupGrabbing();

        //set position to stick out from player
        transform.position = transform.parent.position + transform.up;
    }
}
