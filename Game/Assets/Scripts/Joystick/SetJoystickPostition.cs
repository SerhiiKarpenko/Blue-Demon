using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJoystickPostition : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;


    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            _joystick.transform.position = touchPos;
        }
    }

}
