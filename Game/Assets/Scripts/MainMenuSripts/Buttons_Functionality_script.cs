using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof (SaveStatsForSword))]
public class Buttons_Functionality_script : MonoBehaviour
{
	[SerializeField] private Animator _transitionToMainScene;
	[SerializeField] private GameObject _mainSceneLoaderObject;
	private SaveStatsForSword _saveStatsForSword;
    //[SerializeField] private GameObject LoadingScreen;


    private void Start()
    {
		_saveStatsForSword = GetComponent<SaveStatsForSword>();
    }

    public void OnPlayButtonClick()
	{
		StartCoroutine(LoadMainScene());
	}


	IEnumerator LoadMainScene()
    {
		_mainSceneLoaderObject.SetActive(true);
		_transitionToMainScene.SetTrigger("play");
		
		yield return new WaitForSeconds(2.0f);

		SceneManager.LoadScene("Main_Scene");
	}

	public void OnFirstSwordClick()
    {
		_saveStatsForSword.GetSwordDamageSpeedSprite(0);
		OnPlayButtonClick();
    }

	public void OnSecondSwordClick()
    {
		_saveStatsForSword.GetSwordDamageSpeedSprite(1);
		OnPlayButtonClick();
	}

	public void OnThirdSwordClick()
    {
		_saveStatsForSword.GetSwordDamageSpeedSprite(2);
		OnPlayButtonClick();
	}

	public void OnFourthSwordClick()
    {
		_saveStatsForSword.GetSwordDamageSpeedSprite(3);
		OnPlayButtonClick();
	}

	public void OnFifthSwordClick()
    {
		_saveStatsForSword.GetSwordDamageSpeedSprite(4);
		OnPlayButtonClick();
	}

	public void OpenUrl(string url)
    {
		Application.OpenURL(url);
    }
}
