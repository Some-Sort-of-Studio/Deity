using AudioSystem;
using UnityEngine;

public class AvieryAudio : MonoBehaviour
{
    AudioSource windAudioSource;
    AudioSource chainsAudioSource;

    public GameObject wind;
    public GameObject chains;

    public float chainDelay;
    private bool isChainAudioPlaying;

    private void Start()
    {
        windAudioSource = wind.GetComponent<AudioSource>();
        chainsAudioSource = chains.GetComponent<AudioSource>();

        AudioManager.Instance.PlayAudio("Wind", windAudioSource);
    }

    private void Update()
    {
        if (!isChainAudioPlaying)
        {
            Invoke("PlayChainAudio", chainDelay);
            isChainAudioPlaying = true;
        }
    }

    private void PlayChainAudio()
    {
        AudioManager.Instance.PlayAudio("Chains", chainsAudioSource);
        isChainAudioPlaying = false;
    }

}
