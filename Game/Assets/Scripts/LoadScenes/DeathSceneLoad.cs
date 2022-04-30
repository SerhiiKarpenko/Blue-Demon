using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathSceneLoad : MonoBehaviour
{
    [SerializeField] private Animator _transition;

    private void Start()
    {
        Events.PlayerDied += LoadlLevelWhenPlayerIsDead;
    }

    private void LoadlLevelWhenPlayerIsDead()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        _transition.SetTrigger("Death");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Death_Screen");
    }
}
