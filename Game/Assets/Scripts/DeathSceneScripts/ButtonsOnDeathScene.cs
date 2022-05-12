using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnDeathScene : MonoBehaviour
{
    public void OnBackToMenuButtonClick()
    {
        Events.killedEnemiesCount = 0;
        SceneManager.LoadScene("Main_Menu");
    }
}
