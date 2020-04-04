using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] Sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }*/

        //DontDestroyOnLoad(gameObject);

        foreach (Sounds s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

  
    void Start()
    {
        Play("Theme");
    } 
    public void Play(string name)
    {
        Sounds s = Array.Find(Sounds, Sound => Sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sounds s = Array.Find(Sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
