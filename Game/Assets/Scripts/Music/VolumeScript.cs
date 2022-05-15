using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
            _volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }

    public void SaveVolume()
    {
        float volume;
        bool result = _audioMixer.GetFloat("volume", out volume);
        if (result)
            PlayerPrefs.SetFloat("volume", volume);
        else
            return;
    }
}
