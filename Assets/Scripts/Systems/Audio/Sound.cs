using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    
    [Header("Properties:")]
    public string name = "New Sound";

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume = 0.25f;
    
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;

    public bool loop;    

    [HideInInspector]
    public AudioSource source;
    

}
