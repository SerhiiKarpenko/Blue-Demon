using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnDeathScene : MonoBehaviour
{
    public void OnBackToMenuButtonClick()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
