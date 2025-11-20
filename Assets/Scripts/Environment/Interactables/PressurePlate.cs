using AudioSystem;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent eventWhenActivated;
    [SerializeField] private UnityEvent eventWhenDeactivated;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        eventWhenActivated.Invoke();
        AudioManager.Instance.PlayAudio("PressurePlate", audioSource);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        eventWhenDeactivated.Invoke();
        AudioManager.Instance.PlayAudio("PressurePlate", audioSource);
    }
}
