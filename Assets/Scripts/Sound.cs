using System;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool enabled;
    public bool isSfX, isMusic;

    [HideInInspector]
    public AudioSource source;
}

