using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;
    public TextMeshProUGUI volumeText;
    public AudioMixerGroup musicMixerGroup;
    public string musicMixerParameter = "MusicVolume";

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        musicMixerGroup.audioMixer.SetFloat(musicMixerParameter, Mathf.Log10(musicSlider.value) * 20f);

        volumeText.text = musicSlider.value.ToString("0.00");
    }

    private void SetMusicVolume(float value)
    {
        musicMixerGroup.audioMixer.SetFloat(musicMixerParameter, Mathf.Log10(value) * 20f);

        PlayerPrefs.SetFloat("MusicVolume", value);

        PlayerPrefs.Save();

        volumeText.text = value.ToString("0.00");
    }
}
