using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] audioClips;
    private void Awake()
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

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in audioClips)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    public void Play(string name)
    {
       Sound s = Array.Find(audioClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound named: " + name + " Not Found ");
            return;
        }
        s.source.Play();
    }
}
