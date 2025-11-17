using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent eventWhenActivated;
    [SerializeField] private UnityEvent eventWhenDeactivated;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        eventWhenActivated.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        eventWhenDeactivated.Invoke();
    }
}
