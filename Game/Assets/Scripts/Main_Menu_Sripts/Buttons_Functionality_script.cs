using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons_Functionality_script : MonoBehaviour
{
	[SerializeField] private Image scroll;
	[SerializeField] private Image[] candles;
	[SerializeField] private Slider loadingProccesSlider;
	[SerializeField] private GameObject sliderHolder;
	[SerializeField] private Button playButton;
	//[SerializeField] private GameObject LoadingScreen;
	

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

	public void OnOptionsButtonClick()
	{
		// show options screen
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


	// test method
	public void Test()
    {
		loadingProccesSlider.enabled = true;
		sliderHolder.SetActive(true);
	}

}
