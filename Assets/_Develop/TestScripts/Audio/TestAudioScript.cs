using UnityEngine;
using AudioSystem;

public class TestAudioScript : MonoBehaviour
{
    [SerializeField] AudioData audioData;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        AudioManager.Instance.AddData(audioData);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            AudioManager.Instance.PlayAudio(audioData.ClipName, audioSource);
        }
    }
}
