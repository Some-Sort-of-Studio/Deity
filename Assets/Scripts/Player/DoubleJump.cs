using System.Runtime.CompilerServices;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    PlayerMovement player;
    Rigidbody rb;

    public float doubleJumpMutliplier;

    public bool doubleJump;
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player.grounded)
        {
            doubleJump = true;

            if (Input.GetKeyDown(player.jumpKey))
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(player.jumpKey) && doubleJump)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

                rb.AddForce(transform.up * player.jumpForce * doubleJumpMutliplier, ForceMode.Impulse);

                doubleJump = false;
            }
        }
    }



}
