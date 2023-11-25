using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    public void PlayMusic(string name)
    {
        var sound = Array.Find(music, m => m.name.Equals(name));

        if (sound == null)
        {
            Debug.LogError("sound not found");
            return;
        }

        musicSource.clip = sound.clip;
        musicSource.Play();
    }

    public void PlaySound(string name)
    {
        
    }
}
