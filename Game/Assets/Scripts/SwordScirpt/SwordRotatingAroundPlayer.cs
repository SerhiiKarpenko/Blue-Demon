using UnityEngine;

[RequireComponent(typeof (SwordStats))]
public class SwordRotatingAroundPlayer : MonoBehaviour
{
	[SerializeField] private Transform _player;
	private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = GetComponent<SwordStats>().RotationSpeed;
    }

    private void Update()
    {
        RotateSword();
    }

    private void RotateSword()
    {
        transform.RotateAround(_player.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
