using Unity.VisualScripting;
using UnityEngine;

public class PlatformChange : MonoBehaviour
{
    public enum ObjectState
    { 
        Solid,
        Intangible
    }

    public ObjectState state;

    public GameObject solidState;
    public GameObject intangibleState;

    void Start()
    {
        if (state == ObjectState.Solid)
        {
            solidState.SetActive(true);
            intangibleState.SetActive(false);
        }
        else if (state == ObjectState.Intangible)
        {
            solidState.SetActive(false);
            intangibleState.SetActive(true); 
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SongAOE"))
        {
            SwitchState();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SongAOE"))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        if (state == ObjectState.Solid)
        {
            state = ObjectState.Intangible;
            intangibleState.SetActive(true);
            solidState.SetActive(false);
        }
        else if (state == ObjectState.Intangible)
        {
            state = ObjectState.Solid;
            solidState.SetActive(true);
            intangibleState.SetActive(false);
        }
    }
}
