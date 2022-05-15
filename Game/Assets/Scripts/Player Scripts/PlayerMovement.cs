using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private bool _isMoving = false;
	[SerializeField] private float _speed = 3f;
	[SerializeField] private Animator _playerAnimator;
	[SerializeField] private Joystick _joystick;


    private void Update()
    {
		JoystickMove();
		if(!_isMoving)
			_playerAnimator.SetInteger("Moves", 0);
	}


	private void JoystickMove()
    {
		transform.position += new Vector3(_joystick.Horizontal * _speed * Time.deltaTime, _joystick.Vertical * _speed * Time.deltaTime, 0);
		if (_joystick.Horizontal >= .2f)
        {
			GetComponent<SpriteRenderer>().flipX = false;
			_playerAnimator.SetInteger("Moves", 1);
			CheckIsPlayerMoving(true);
			
		}
		else if(_joystick.Horizontal <= -.2f)
        {
			GetComponent<SpriteRenderer>().flipX = true;
			_playerAnimator.SetInteger("Moves", 1);
			CheckIsPlayerMoving(true);
		}
		else
        {
			CheckIsPlayerMoving(false);
		}
	}

	private void CheckIsPlayerMoving(bool isMoving)
    {
		_isMoving = isMoving;
    }

	public void IncreasePlayerMoveSpeed(float speed)
    {
		_speed += speed;
    }



}
