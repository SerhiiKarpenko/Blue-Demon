using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneIgnoreCollisions : MonoBehaviour
{
    private GameObject _player;
    private Collider2D _playerCollider;
    private Collider2D _magicStoneCollider;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _playerCollider = _player.GetComponent<Collider2D>();
        _magicStoneCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        IgnorePlayerColider();
    }

    private void IgnorePlayerColider()
    {
        Physics2D.IgnoreCollision(_magicStoneCollider, _playerCollider, true);    
    }

}
