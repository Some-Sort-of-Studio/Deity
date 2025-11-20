using AudioSystem;
using UnityEngine;

public class AudioSwitchTrigger : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject firstAudio;
    public GameObject secondAudio;

    private void Start()
    {
        audioSource = firstAudio.GetComponent<AudioSource>();
        AudioManager.Instance.PlayAudio("Underground", audioSource);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   

        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.StopAudio(audioSource);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource = secondAudio.GetComponent<AudioSource>();

        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio("Tower", audioSource);
        }
    }
}
