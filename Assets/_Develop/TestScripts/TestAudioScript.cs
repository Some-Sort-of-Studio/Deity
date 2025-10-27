using AudioSystem;
using UnityEngine;

public class TestAudioScript : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void DoSomething()
    {
        AudioManager.Instance.PlayAudio("Plr_Walk_1", audioSource);
    }
}
