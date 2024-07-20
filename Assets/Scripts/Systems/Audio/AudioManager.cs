using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public Sound[] audioClips;

    private Dictionary<string, Queue<AudioSource>> audioSourcePool;
    public static AudioManager m_AudioManager { get; private set;}



    private void Awake()
    {
        if (m_AudioManager == null)
        {
            m_AudioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSourcePool = new Dictionary<string, Queue<AudioSource>>();

        foreach (Sound s in audioClips)
        {
            s.source = CreateAudioSource(s);
        }
    }

    private AudioSource CreateAudioSource(Sound sound)
    {
        GameObject audioSourceObject = new GameObject(sound.name + "audioSource");
        audioSourceObject.transform.SetParent(transform);

        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = sound.audioClip;
        audioSource.volume = sound.volume;
        audioSource.pitch = sound.pitch;
        audioSource.loop = sound.loop;

        if (!audioSourcePool.ContainsKey(sound.name))
        {
            audioSourcePool[sound.name] = new Queue<AudioSource>();
        }

        audioSourcePool[sound.name].Enqueue(audioSource);

        return audioSource;
    }

    private AudioSource GetAvailableAudioSource(string name)
    {
        if (audioSourcePool.ContainsKey(name) || audioSourcePool[name].Count == 0)
        {
            return CreateAudioSource(Array.Find(audioClips, sound => sound.name == name));
        }
        return audioSourcePool[name].Dequeue();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(audioClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound named: " + name + " Not Found ");
            return;
        }
        AudioSource audioSource = GetAvailableAudioSource(name);
        s.source.Play();
    }
}
