using UnityEngine;

enum MOVING_STATES { up, down, right, left, none };

public class PlayerMovement : MonoBehaviour
{
	private MOVING_STATES _movingState = MOVING_STATES.none;
	[SerializeField] private float _speed = 5f;
	[SerializeField] private Animator _playerAnimator;

    private void Update()
    {
        switch(_movingState)
        {
			case MOVING_STATES.up:
				MoveUp();
				break;
			case MOVING_STATES.down:
				MoveDown();
				break;
			case MOVING_STATES.right:
				MoveRight();
				break;
			case MOVING_STATES.left:
				MoveLeft();
				break;
			default:
				_movingState = MOVING_STATES.none;
				_playerAnimator.SetInteger("Moves", 0);
				break;
				
        }
    }

	public void OnMoveUpButtonDown() { _movingState = MOVING_STATES.up; }
	public void OnMoveDownButtonDown() { _movingState = MOVING_STATES.down; }
	public void OnMoveRightButtonDown() { _movingState = MOVING_STATES.right; }
	public void OnMoveLeftButtonDown() { _movingState = MOVING_STATES.left; }
	public void OnEachButtonUp() { _movingState = MOVING_STATES.none; }


    private void MoveUp()
	{
		transform.position += Vector3.up * _speed * Time.deltaTime;
		_playerAnimator.SetInteger("Moves", 1);
	}

	private void MoveDown()
	{
		transform.position += Vector3.down * _speed * Time.deltaTime;
		_playerAnimator.SetInteger("Moves", 1);
	}

	private void MoveRight()
	{
		transform.position += Vector3.right * _speed * Time.deltaTime;
		GetComponent<SpriteRenderer>().flipX = false;
		_playerAnimator.SetInteger("Moves", 1);
	}

	private void MoveLeft()
    {
		transform.position += Vector3.left * _speed * Time.deltaTime;
		GetComponent<SpriteRenderer>().flipX = true;
		_playerAnimator.SetInteger("Moves", 1);
	}



}
