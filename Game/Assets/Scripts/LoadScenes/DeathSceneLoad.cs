using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathSceneLoad : MonoBehaviour
{
    [SerializeField] private Animator _transition;

    private void Start()
    {
        PlayerHealth.OnDeathEvent += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        _transition.SetTrigger("Death");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("DeathScreen");
    }
}
