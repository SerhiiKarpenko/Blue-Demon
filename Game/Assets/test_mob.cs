using UnityEngine;

public class test_mob : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 3;

    private void Update()
    {
       gameObject.GetComponent<SpriteRenderer>().flipX = transform.position.x - _player.transform.position.x < 0.0f;

       if (Vector3.Distance(transform.position, _player.transform.position) > 0.5f)
       {
           transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
       }
    }
}
