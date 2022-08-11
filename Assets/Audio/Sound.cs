using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[Serializable]
public class Sound
{ 
    public string name;
    public AudioClip clip;
   
    [Range(0f, 1f)]
    public float volume;
   
    [Range(.1f, 3f)]
    public float pitch;

    public SoundType type;
   
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

public enum SoundType
{
    SFX,
    Music,
}
