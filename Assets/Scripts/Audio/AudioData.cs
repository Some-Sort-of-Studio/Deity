using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "Audio Assets", order = 1)]
    public class AudioData : ScriptableObject
    {
        public string ClipName;
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public bool IsLooping;
    }
}
