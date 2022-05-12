using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// ����������� ������ Events.PlayerDied -= LoadlLevelWhenPlayerIsDead; ����� ���������� ���
public class DeathSceneLoad : MonoBehaviour
{
    [SerializeField] private Animator _transition;

    private void Awake()
    {
        Events.PlayerDied += LoadlLevelWhenPlayerIsDead;
    }


   public void LoadlLevelWhenPlayerIsDead() => StartCoroutine(LoadLevel());

    IEnumerator LoadLevel()
    {
        _transition.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        Events.PlayerDied -= LoadlLevelWhenPlayerIsDead;
        SceneManager.LoadScene("Death_Screen");
    }
}
