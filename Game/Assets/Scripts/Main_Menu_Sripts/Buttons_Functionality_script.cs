using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_Functionality_script : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        //load the main scene, or character choose screen
        /* first play animation, second loading screen, finaly main scene */ 

    }

    public void OnOptionsButtonClick()
    {
        // show options screen
    }

    public void OnExitButtonClick()
    {
        // this function is not necessary, because users will close the game with home button
        Application.Quit();
    }
}
