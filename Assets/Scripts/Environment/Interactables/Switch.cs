using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [Tooltip("Set this to true if starts activated")]
    [SerializeField] private bool active;
    [SerializeField] private UnityEvent eventWhenActivated;

    public void ToggleSwitch()
    {
        active = !active;

        if (active) //if switch has been activated just now then run the associated event
        {
            eventWhenActivated.Invoke();
        }
    }
}
