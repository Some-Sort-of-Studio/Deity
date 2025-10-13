using UnityEngine;

public class FirePoint : MonoBehaviour
{
    //to run just before a projectile is instantiated
    public void SetupFiring()
    {
        ////ONLY WORKS WITH ORTHOGRAPHIC CAMERA
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position) - Vector3.up;
        Vector3 mousePosition = Input.mousePosition - playerScreenPoint; //player to mouse

        //get z angle from x and y
        float angleRadius = Mathf.Atan2(mousePosition.y - transform.parent.position.y, mousePosition.x - transform.parent.position.x);
        float angleDegrees = 180 / Mathf.PI * angleRadius - 90; //offset this by 90 degrees

        transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        //set position to stick out from player
        transform.position = transform.parent.position + transform.up;
    }
}
