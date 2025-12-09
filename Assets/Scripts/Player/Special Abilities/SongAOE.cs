using System.Collections;
using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SongAOE : MonoBehaviour
{
    public bool songAOEEnabled = true;

    public GameObject AOEAir;
    private AudioSource audioSource;

    private bool usingAbility;

    PlayerMovement2D player;

    void Start()
    {
        AOEAir.SetActive(false);
        //audioSource = AOEAir.GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement2D>();
        usingAbility = false;
    }

    private void Update()
    {
        if (usingAbility)
        {
            AOEAir.SetActive(true);
        }
        else
        {
            AOEAir.SetActive(false);
        }
    }

    public void SongAOEAbility(InputAction.CallbackContext context)
    {
        if (!songAOEEnabled) return;

        if (context.performed)
        {
            usingAbility = true;
            //AudioManager.Instance.PlayAudio("Song_AOE", audioSource);
        }
        else if(context.canceled)
        {
            usingAbility = false;
            //AudioManager.Instance.StopAudio(audioSource);
        }
    }
}
