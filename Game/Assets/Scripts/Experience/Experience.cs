using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private float _amount;

    public float Amount => _amount;
    public void SetAmount(float amount)
    {
        _amount = amount;
    }

}
