using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            AudioManager.instance.Play("Main Menu BGM");
        }
        else if (SceneManager.GetActiveScene().name == "VSLevel1")
        {
            AudioManager.instance.Play("Level BGM");
            AudioManager.instance.Play("Busy Street SFX");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
        s.isPlaying = true;
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Stop();
        s.isPlaying = false;
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Pause();
        s.isPlaying = false;
    }

    public void Unpause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.UnPause();
        s.isPlaying = true;
    }
    
    public bool CheckIfPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return false;
        }
        if (s.isPlaying == true)
            return true;
        else if (s.isPlaying == false)
            return false;

        return false;
    }

    public void OffVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.volume = volume;
    }

    public void OnVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.volume = volume;
    }
}
