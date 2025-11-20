using AudioSystem;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [Tooltip("Set this to true if starts activated")]
    [SerializeField] private bool active;
    [SerializeField] private UnityEvent eventWhenActivated;
    [SerializeField] private UnityEvent eventWhenDeactivated;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleSwitch()
    {
        active = !active;

        if (active) //if switch has been activated just now then run the associated event
        {
            eventWhenActivated.Invoke();
            AudioManager.Instance.PlayAudio("Switch", audioSource);
        }

        if (!active)
        {
            eventWhenDeactivated.Invoke();
            AudioManager.Instance.PlayAudio("Switch", audioSource);
        }
    }
}
