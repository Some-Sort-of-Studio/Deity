using UnityEngine;
using UnityEngine.Audio;


namespace AudioSystem
{
    [System.Serializable]
    public class AudioData
    {
        [Header("Audio Clip Name")]
        public string ClipName;

        [Header("Audio Clip")]
        public AudioClip Clip;

        [Header("Audio Mixer Group")]
        public AudioMixerGroup MixerGroup;

        [Header("Does The Audio Loop?")]
        public bool IsLooping;
    }

}
