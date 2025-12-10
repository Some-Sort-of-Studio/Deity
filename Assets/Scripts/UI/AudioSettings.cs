using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Slider References:")]
    [SerializeField] private Slider MasterVolSlider;
    [SerializeField] private Slider PlayerVolSlider;
    [SerializeField] private Slider EnvironmentVolSlider;
    [SerializeField] private Slider MusicVolSlider;

    [Header("Mixer:")]
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MainVolume", Mathf.Log10(sliderValue) * 20);
    }

    // sets the music volume according to the slider.
    public void SetMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    // sets the environment volume according to the slider.
    public void SetEnvrionmentVolume(float sliderValue)
    {
        audioMixer.SetFloat("EnvrionmentVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetPlayerVolume(float sliderValue)
    {
        audioMixer.SetFloat("PlayerVolume", Mathf.Log10(sliderValue) * 20);
    }

}
