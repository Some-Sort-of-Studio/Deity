using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        //public Dictionary<string, AudioData> AudioDataLibrary = new();
        public List<AudioData> AudioDataLibrary = new();

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

        public void PlayAudio(string clipname, AudioSource audioSource)
        {
            if(audioSource == null)
            {
                Debug.LogWarning("Cannot find Audio Source!");
                return;
            }
            
            for (int i = 0; i < AudioDataLibrary.Count; i++)
            {
                if (AudioDataLibrary[i].ClipName == clipname)
                {
                    SetAudioData(audioSource, AudioDataLibrary[i]);

                    audioSource.Play();
                }
            }

            Debug.LogWarning($"Cannot find AudioClip {clipname}");
        }

        static void SetAudioData(AudioSource source, AudioData data)
        {
             source.clip = data.Clip;
             source.outputAudioMixerGroup = data.MixerGroup;
             source.loop = data.Clip;
        }
    }

}
