using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class IgnoreCollider : MonoBehaviour
{
	[SerializeField] private Collider2D _swordCollider;
	private Collider2D _objectCollider;

	private void Start()
	{
		_objectCollider = GetComponent<Collider2D>();
		Physics2D.IgnoreCollision(_swordCollider, _objectCollider, true);
	}
}
