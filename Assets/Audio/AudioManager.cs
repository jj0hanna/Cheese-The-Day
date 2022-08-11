using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] sounds;

        private static AudioManager instance;

        public static float masterVolume = 1;

        public static Dictionary<SoundType, float> TypeVolume;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            TypeVolume = new Dictionary<SoundType, float>();
            foreach (SoundType soundType in Enum.GetValues(typeof(SoundType)))
            {
                TypeVolume.Add(soundType, 1);
            }

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();

                s.source.clip = s.clip;
                s.source.loop = s.loop;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }

        public static void setMasterVolume(float Volume)
        {
            masterVolume = Volume;
            UpdateSoundSource();
        }

        public static void setTypeVolume(SoundType type, float volume)
        {
            TypeVolume[type] = volume;
            UpdateSoundSource();
        }

        private static void UpdateSoundSource()
        {
            // volume 0 - 1... 0.5
            foreach (Sound s in instance.sounds)
            {
                float typeVolume = TypeVolume[s.type];
                s.source.volume = s.volume * typeVolume * masterVolume;
            }
        }

        public static void PlaySound(string name)
        {
            foreach (Sound s in instance.sounds)
            {
                if (s.name == name)
                {
                    if (s.loop && s.source.isPlaying)
                    {
                        continue;
                    }

                    s.source.Play();
                }
            }
        }

        public static void StopSound(string name)
        {
            foreach (Sound s in instance.sounds)
            {
                if (s.name == name)
                {
                    s.source.Stop();
                }
            }
        }
    }
}