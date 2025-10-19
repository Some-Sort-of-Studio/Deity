using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DoubleJump : MonoBehaviour
{
    PlayerMovement player;
    Rigidbody2D rb;

    public float doubleJumpMutliplier;

    public bool doubleJump;
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
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
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, 0);

                rb.AddForce(transform.up * player.jumpForce * doubleJumpMutliplier, ForceMode2D.Impulse);

                doubleJump = false;
            }
        }
    }



}
