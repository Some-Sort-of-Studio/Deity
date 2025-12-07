using System.Collections;
using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SongAOE : MonoBehaviour
{
    public bool songAOEEnabled = true;

    public GameObject AOEGround;
    public GameObject AOEAir;
    private AudioSource audioSource;

    private bool usingAbility;

    PlayerMovement2D player;

    void Start()
    {
        AOEGround.SetActive(false);
        AOEAir.SetActive(false);
        audioSource = AOEGround.GetComponent<AudioSource>();
        audioSource = AOEAir.GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement2D>();
        usingAbility = false;
    }

    private void Update()
    {
        if (player.isGrounded && usingAbility)
        {
            AOEGround.SetActive(true);
            AOEAir.SetActive(false);
        }

        if (!player.isGrounded && usingAbility)
        {
            AOEAir.SetActive(true);
            AOEGround.SetActive(false);
        }

        if (!usingAbility)
        {
            AOEGround.SetActive(false);
            AOEAir.SetActive(false);
        }
    }

    public void SongAOEAbility(InputAction.CallbackContext context)
    {
        if (!songAOEEnabled) return;

        if (context.performed)
        {
            usingAbility = true;
            AudioManager.Instance.PlayAudio("Song_AOE", audioSource);
        }
        else if(context.canceled)
        {
            usingAbility = false;
            AudioManager.Instance.StopAudio(audioSource);
        }
    }
}
