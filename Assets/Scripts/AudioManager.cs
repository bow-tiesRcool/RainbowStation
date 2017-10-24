using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


    [Range(0f, 1f)]
    public float SFXVolume, MusicVolume;

    public static AudioManager instance;

    private ButtonManager BMan;

    private void Update()
    {
        BMan = FindObjectOfType<ButtonManager>();
        if (BMan == null)
        {
            return;
        }
        SFXVolume = BMan.SFXVolume;
        MusicVolume = BMan.MusicVolume;
    }

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.enabled = s.enabled;
        }
    }


    void LateUpdate()
    {
        Debug.Log(MusicVolume);

        foreach (Sound s in sounds)
        {
            if (s.isSfX)
            {
                s.source.volume = this.SFXVolume;
            }
            if (s.isMusic)
            {
                s.source.volume = this.MusicVolume;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }


}
