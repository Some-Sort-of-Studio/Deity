using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioSettings : MonoBehaviour
{
    [Header("Slider References:")]
    [SerializeField] private Slider MasterVolSlider;
    [SerializeField] private Slider PlayerVolSlider;
    [SerializeField] private Slider EnvironmentVolSlider;
    [SerializeField] private Slider SFXVolSlider;

    public enum Volume { Master, Player, Environment, SFX };

    public Volume volume;

    [Header("Mixer:")]
    [SerializeField] private AudioMixer mainMixer;

    public void SetVolume(float value)
    {

    }

    private void SavePrefs()
    {

    }

}
