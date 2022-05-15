using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class ButtonsOnMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private AudioMixer _audioMixer;
    private bool _isPaused = false;
    private float _volume;

    private void Start()
    {
        _volume = GetAudioMixerVolume();
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _playerUI.SetActive(true);
        Time.timeScale = 1f;
        _isPaused = false;
        SetAudioMixerVolume(_volume, _audioMixer);
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _playerUI.SetActive(false);
        _isPaused = true;
        Time.timeScale = 0f;
        SetAudioMixerVolume(-80f, _audioMixer);
    }

    public void LoadMenu()
    {
        Events.killedEnemiesCount = 0;
        SceneManager.LoadScene("Main_menu");
        Time.timeScale = 1f;
    }

    private void SetAudioMixerVolume(float volume, AudioMixer mixer)
    {
        mixer.SetFloat("volume", volume);
    }

    private float GetAudioMixerVolume()
    {
        float volume;
        bool result = _audioMixer.GetFloat("volume", out volume);
        if (result)
            return volume;
        else
            return 0f;
    }


}
