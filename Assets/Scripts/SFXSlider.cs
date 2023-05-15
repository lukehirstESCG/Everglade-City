using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXSlider : MonoBehaviour
{
    public TextMeshProUGUI volumeText;
    public Slider sfxSlider;
    public AudioMixerGroup sfxMixerGroup;
    public string sfxMixerParameter = "SFXVolume";

    private void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        volumeText.text = sfxSlider.value.ToString("0.00");

        sfxMixerGroup.audioMixer.SetFloat(sfxMixerParameter, Mathf.Log10(sfxSlider.value) * 20f);
    }

    private void SetSFXVolume(float value)
    {
        sfxMixerGroup.audioMixer.SetFloat(sfxMixerParameter, Mathf.Log10(value) * 20f);

        PlayerPrefs.SetFloat("SFXVolume", value);

        PlayerPrefs.Save();

        volumeText.text = value.ToString("0.00");
    }
}
