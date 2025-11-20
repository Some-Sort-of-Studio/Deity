using AudioSystem;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSwitchTrigger : MonoBehaviour
{
    AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource = collision.gameObject.GetComponent<AudioSource>();       

        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.StopAudio(audioSource);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource = collision.gameObject.GetComponent<AudioSource>();

        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio("Tower", audioSource);
        }
    }
}
