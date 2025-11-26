using System.Collections;
using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SongAOE : MonoBehaviour
{
    public bool songAOEEnabled = true;

    public GameObject AOE;
    private AudioSource audioSource;

    void Start()
    {
        AOE.SetActive(false);
        audioSource = AOE.GetComponent<AudioSource>();
    }

    public void SongAOEAbility(InputAction.CallbackContext context)
    {
        if (!songAOEEnabled) return;

        if (context.performed)
        {
            AOE.SetActive(true);
            AudioManager.Instance.PlayAudio("Song_AOE", audioSource);
        }
        else if(context.canceled)
        {
            AOE.SetActive(false);
            AudioManager.Instance.StopAudio(audioSource);
        }
    }
}
