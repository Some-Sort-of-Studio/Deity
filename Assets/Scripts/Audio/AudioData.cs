using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    public class AudioData : ScriptableObject
    {
        public string ClipName;
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public bool IsLooping;
    }
}
