using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof (SaveStatsForSword))]
public class Buttons_Functionality_script : MonoBehaviour
{
	[SerializeField] private Image scroll;
	[SerializeField] private Image[] candles;
	[SerializeField] private Slider loadingProccesSlider;
	[SerializeField] private GameObject sliderHolder;
	[SerializeField] private Button playButton;
	private SaveStatsForSword _saveStatsForSword;
    //[SerializeField] private GameObject LoadingScreen;


    private void Start()
    {
		_saveStatsForSword = GetComponent<SaveStatsForSword>();
    }

    public void OnPlayButtonClick()
	{
		//load the main scene, or character choose screen
		/* first play animation, second loading screen, finaly main scene */ 

		for (int i = 0; i < candles.Length; i++)
			candles[i].enabled = false;

		scroll.enabled = false;
		playButton.enabled = false;

		StartCoroutine(LoadAsynchronously());

	}


	IEnumerator LoadAsynchronously()
    {
		AsyncOperation operation = SceneManager.LoadSceneAsync("Main_Scene");
		sliderHolder.SetActive(true);
		while (!operation.isDone)
        {
			//Debug.Log(loadingProccesSlider.value);
			float progress = Mathf.Clamp01(operation.progress / .9f);
			loadingProccesSlider.value = progress;
			//Debug.Log(loadingProccesSlider.value);
			
			yield return null;
        }
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
	

	// test method
	public void Test()
    {
		loadingProccesSlider.enabled = true;
		sliderHolder.SetActive(true);
	}

}
