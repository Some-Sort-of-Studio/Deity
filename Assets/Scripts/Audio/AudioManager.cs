using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        public readonly Dictionary<string, AudioData> AudioDataLibrary = new();

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

        public void AddData(AudioData data)
        {
            AudioDataLibrary.Add(data.ClipName, data);
        }

        public void PlayAudio(string clipname, AudioSource audioSource)
        {
            if(AudioDataLibrary.ContainsKey(clipname))
            {
                audioSource.clip = AudioDataLibrary[clipname].Clip;
                audioSource.outputAudioMixerGroup = AudioDataLibrary[clipname].MixerGroup;
                audioSource.loop= AudioDataLibrary[clipname].IsLooping;

                audioSource.Play();
            }
        }

        public void RemoveData(AudioData data)
        {
            AudioDataLibrary.Remove(data.ClipName);
        }
    }

}
