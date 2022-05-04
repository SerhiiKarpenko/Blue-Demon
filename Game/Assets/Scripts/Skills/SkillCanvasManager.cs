using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCanvasManager : MonoBehaviour
{
    [SerializeField] private SkillData[] _skillDatas;
    [SerializeField] private GameObject[] _skillSlots;
    [SerializeField] private GameObject _skillsCanvas;
    [SerializeField] private Image[] _skillImages;
    [SerializeField] private TextMeshProUGUI[] _skillNames;
    [SerializeField] private TextMeshProUGUI[] _skillDescription;
    [SerializeField] private GameObject _player;

    public void ShowSkills()
    {
        Time.timeScale = 0;
        _skillsCanvas.SetActive(true);
        SetRandomSkillsFromSkillData();
    }

    private void SetRandomSkillsFromSkillData()
    {
        for(int i = 0; i < _skillImages.Length; i++)
        {
            SkillData skillData = _skillDatas[Random.Range(0, _skillDatas.Length)];
            _skillImages[i].sprite = skillData.Icon;
            _skillNames[i].text = skillData.Name;
            _skillDescription[i].text = skillData.Description;
        }
    }

    public void OnSkillSlotClikc()
    {
        //add new skill to player, continue playing
        Time.timeScale = 1;
        _skillsCanvas.SetActive(false);
    }
    
    
}
