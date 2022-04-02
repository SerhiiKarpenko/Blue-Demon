using UnityEngine;


public class test : MonoBehaviour
{
	[SerializeField] private GameObject _player;
	[SerializeField] private float _rotationSpeed;

	private void Update()
	{
		transform.RotateAround(_player.transform.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
	}
}
