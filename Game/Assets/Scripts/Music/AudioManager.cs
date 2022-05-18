using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _musicMixer;
    private AudioListener _audioListener;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Events.PlayerDied += SetEffectsVolumeOnZero;
        _audioListener = GetComponent<AudioListener>();
    }

    [SerializeField] private AudioSource[] _audioSources;

    public void Play(string name)
    {
        AudioSource s = Array.Find(_audioSources, _audioSource => _audioSource.clip.name == name);
        s.Play();
    }

    public void SetEffectsVolumeOnZero()
    {
        _audioListener.enabled = true;
        _musicMixer.SetFloat("MusicVolume", -80f);
    }

    private void OnDestroy()
    {
        Events.PlayerDied -= SetEffectsVolumeOnZero;
    }

}
