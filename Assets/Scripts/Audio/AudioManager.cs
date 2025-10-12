using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        public readonly List<AudioData> AudioDataLibrary = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

        public void PlayAudio(string clipname, AudioSource audioSource)
        {
            for (int i = 0; i < AudioDataLibrary.Count; i++)
            {
                if (AudioDataLibrary[i].ClipName == clipname)
                {
                    SetAudioData(AudioDataLibrary[i], audioSource);

                    audioSource.Play();
                }
            }
        }

        static void SetAudioData(AudioData data, AudioSource source)
        {
            source.clip = data.Clip;
            source.outputAudioMixerGroup = data.MixerGroup;
            source.loop = data.IsLooping;
        }

    }
}
