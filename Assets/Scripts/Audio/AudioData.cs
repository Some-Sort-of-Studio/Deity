using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "Audio Data", menuName = "Audio Assets", order = 0)]
    public class AudioData : ScriptableObject
    {
        public string ClipName;
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
        public bool IsLooping;
    }
}
