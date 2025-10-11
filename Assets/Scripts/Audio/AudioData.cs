using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [System.Serializable]
    public class AudioData
    {
        public string ClipName;
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public bool IsLooping;
    }
}
