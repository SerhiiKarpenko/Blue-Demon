using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New skill", menuName = "Skills")]
public class SkillData : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
}
