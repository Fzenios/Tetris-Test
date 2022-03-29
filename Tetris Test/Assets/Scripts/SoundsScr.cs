using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class SoundsScr : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;


        [HideInInspector]
        public AudioSource source;

    }
    public Sound[] Sounds;
    public AudioMixerGroup MusicGroup;

    void Awake()
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = false;
            s.source.clip = s.Clip;
            s.source.outputAudioMixerGroup = MusicGroup;
        }
    }

    public void RowClip()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Row");
        if (s != null)
        {
            s.source.PlayOneShot(s.Clip);
        }
    }
}
