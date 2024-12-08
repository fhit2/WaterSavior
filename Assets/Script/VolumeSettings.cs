using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer masterMixer;

    private void Start()
    {
        float savedSFXVolume = PlayerPrefs.GetFloat("SavedSFXVolume", 100);
        float savedMusicVolume = PlayerPrefs.GetFloat("SavedMusicVolume", 100);

        SetSFXVolume(savedSFXVolume);
        SetMusicVolume(savedMusicVolume);
    }

    public void SetSFXVolume(float _value)
    {
        if(_value < 1)
        {
            _value = .001f;
        }

        RefreshSFXSlider(_value);
        PlayerPrefs.SetFloat("SavedSFXVolume", _value);
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetMusicVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshMusicSlider(_value);
        PlayerPrefs.SetFloat("SavedMusicVolume", _value);
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetSFXVolumeFromSlider()
    {
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMusicVolumeFromSlider()
    {
        SetMusicVolume(musicSlider.value);
    }

    public void RefreshSFXSlider(float _value)
    {
        sfxSlider.value = _value;
    }

    public void RefreshMusicSlider(float _value)
    {
        musicSlider.value = _value;
    }
}
