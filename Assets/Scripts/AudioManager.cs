using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [SerializeField] AudioMixer mixer;
    public static AudioManager instance;
    public AudioMixerGroup mixergroup;

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SFXVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        LoadVolume();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            if (s.mixergroup == null)
            {
                s.source.outputAudioMixerGroup = mixergroup;
            }
            else
            {
                s.source.outputAudioMixerGroup = s.mixergroup;
            }
        }
        
    }
    void Start()
    {
        Play("TEST");
    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound : " + name + " was not found! Please try again!");
            return;
        }
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }
    void LoadVolume() // Volume Saved in VolumeSettings.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10 (musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
    public void MuteHandler(bool mute)
    {
        if(mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
