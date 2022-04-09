using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(EnemyHealth))]
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider _healthPointSlider;
    [SerializeField] private Vector3 _offset;


    private void Start()
    {
        _healthPointSlider.maxValue = GetComponentInParent<EnemyHealth>().MaxHealth;
        _healthPointSlider.value = _healthPointSlider.maxValue;
    }

    private void Update()
    {
        _healthPointSlider.gameObject.SetActive(GetComponentInParent<EnemyHealth>().CurrentHealth < GetComponentInParent<EnemyHealth>().MaxHealth);
        _healthPointSlider.value = GetComponentInParent<EnemyHealth>().CurrentHealth;
        _healthPointSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }
}