using UnityEngine;

public class SwordRotationOnMainMenu : MonoBehaviour
{
	[SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0,_rotationSpeed, 0) * Time.deltaTime);
    }
}
