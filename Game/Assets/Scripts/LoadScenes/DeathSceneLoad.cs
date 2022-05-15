using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// ����������� ������ Events.PlayerDied -= LoadlLevelWhenPlayerIsDead; ����� ���������� ���
public class DeathSceneLoad : MonoBehaviour
{
    [SerializeField] private Animator _transition;

    public static DeathSceneLoad Instance;


    private void Awake()
    {
        Instance = this;
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
