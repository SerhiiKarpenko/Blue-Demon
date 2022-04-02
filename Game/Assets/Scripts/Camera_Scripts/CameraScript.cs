using UnityEngine;

public class CameraScript : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _offset;
	[SerializeField] private float _speed = 1.5f;

	private void Update()
	{
		Vector3 positionWhatWeLookingFor = _target.transform.position + _offset;
		Vector3 SmothedPositionWhatWeLookingFor = Vector3.Lerp(transform.position, positionWhatWeLookingFor, _speed * Time.deltaTime);
		transform.position = SmothedPositionWhatWeLookingFor;
	}
}
