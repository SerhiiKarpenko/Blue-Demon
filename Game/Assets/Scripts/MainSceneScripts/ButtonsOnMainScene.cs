using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class ButtonsOnMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private AudioMixer _effectsMixer;
    [SerializeField] private AudioMixer _musicMixer;
    private bool _isPaused = false;
    private float _effectsVolume;
    private float _musicVolume;

    private void Start()
    {
        _effectsVolume = GetAudioMixerVolume(_effectsMixer, "EffectsVolume");
        _musicVolume = GetAudioMixerVolume(_musicMixer, "MusicVolume");
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _playerUI.SetActive(true);
        Time.timeScale = 1f;
        _isPaused = false;
        SetAudioMixerVolume(_effectsVolume, _effectsMixer, "EffectsVolume");
        SetAudioMixerVolume(_musicVolume, _musicMixer, "MusicVolume");
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _playerUI.SetActive(false);
        _isPaused = true;
        Time.timeScale = 0f;
        SetAudioMixerVolume(-80f, _effectsMixer, "EffectsVolume");
        SetAudioMixerVolume(-80f, _musicMixer, "MusicVolume");
    }

    public void LoadMenu()
    {
        Events.killedEnemiesCount = 0;
        SceneManager.LoadScene("Main_menu");
        Time.timeScale = 1f;
    }

    private void SetAudioMixerVolume(float volume, AudioMixer mixer, string parametr)
    {
        mixer.SetFloat(parametr, volume);
    }

    private float GetAudioMixerVolume(AudioMixer mixer, string paramter)
    {
        float volume;
        bool result = mixer.GetFloat(paramter, out volume);
        if (result)
            return volume;
        else
            return 0f;
    }


}
