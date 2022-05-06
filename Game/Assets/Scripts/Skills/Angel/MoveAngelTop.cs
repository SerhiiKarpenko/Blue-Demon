using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAngelTop : MonoBehaviour
{
    private float _speed = 0.3f;
    private float _timeTobeDestroyed = 2f;
    private Vector3 _scaleChange = new Vector3(0.01f,0.01f,0.01f);

    private void Update()
    {
        MoveUp();
        _timeTobeDestroyed -= Time.deltaTime;
        if(_timeTobeDestroyed <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void MoveUp()
    {
        GrowUp();
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        _speed+= 0.1f;
    }

    private void GrowUp()
    {
        gameObject.transform.localScale += _scaleChange;
    }
}
