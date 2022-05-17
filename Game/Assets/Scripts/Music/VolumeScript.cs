using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
	[SerializeField] private AudioMixer _audioMixer;
	[SerializeField] private AudioMixer _effectsMixer;
	[SerializeField] private Slider _volumeSlider;
	[SerializeField] private Slider _effectsSlider;

	private void Start()
	{
		_volumeSlider.value = PlayerPrefs.GetFloat("music_volume");
		_effectsSlider.value = PlayerPrefs.GetFloat("effects_volume");
	}

	public void SetMusicVolume(float volume)
	{
		_audioMixer.SetFloat("MusicVolume", volume);
	}

	public void SetEffectsVolume(float volume)
    {
		_effectsMixer.SetFloat("EffectsVolume", volume);
    }

	public void SaveMusicVolume()
	{
		float volume;
		bool result = _audioMixer.GetFloat("MusicVolume", out volume);
		if (result)
			PlayerPrefs.SetFloat("music_volume", volume);
		else
			return;
	}

	public void SaveEffectsVolume()
    {
		float volume;
		bool result = _effectsMixer.GetFloat("EffectsVolume", out volume);
		if (result)
			PlayerPrefs.SetFloat("effects_volume", volume);
		else
			return;
	}
}
