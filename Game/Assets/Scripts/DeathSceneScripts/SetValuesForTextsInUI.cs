using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetValuesForTextsInUI : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string _note;

    [Tooltip("first element of this array wiil be ENEMIES KILLED TEXT, second PLAYER LEVEL TEXT")]
    [SerializeField] private TextMeshProUGUI[] _textsOnDeathScene;

    private void Start()
    {
        _textsOnDeathScene[0].text = "Enemies killed: " + PlayerPrefs.GetInt("Count_of_killed_enemies");
        _textsOnDeathScene[1].text = "Player level: " + PlayerPrefs.GetInt("Player_level");
    }
}
