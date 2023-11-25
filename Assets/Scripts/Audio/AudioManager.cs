using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        } 
    }
    
    public void PlayMusic(string name)
    {
        var sound = FindSound(name, music);

        musicSource.clip = sound.clip;
        musicSource.Play();
    }

    public void PlaySound(string name)
    {
        var sound = FindSound(name, sfx);

        sfxSource.PlayOneShot(sound.clip);
    }
    
    private static Sound FindSound(string name, Sound[] array)
    {
        var sound = Array.Find(array, m => m.name.Equals(name));

        if (sound != null) return sound;
        Debug.LogError("sound not found");
        return sound;
    }
}
