using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public AudioMixerGroup musicMixerGroup;
    public AudioMixerGroup sfxMixerGroup;

    void Start()
    {
        Play("TEST");
    }

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
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;

            // Set the appropriate mixer group for the sound
            if (s.isMusic)
            {
                s.source.outputAudioMixerGroup = musicMixerGroup;
            }
            else
            {
                s.source.outputAudioMixerGroup = sfxMixerGroup;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
        s.source.Play();
    }
    public void MuteHandler(bool mute)
    {
        float volume = mute ? 0f : 1f;
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * volume;
        }
    }
}
