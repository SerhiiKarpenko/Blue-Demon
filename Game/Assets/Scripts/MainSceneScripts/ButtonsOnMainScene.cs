using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonsOnMainScene : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _playerUI;
    private bool _isPaused = false;

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _playerUI.SetActive(true);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _playerUI.SetActive(false);
        _isPaused = true;
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }


}
