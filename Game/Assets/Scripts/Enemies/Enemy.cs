using UnityEngine;

[RequireComponent(typeof (EnemyHealth))]
[RequireComponent(typeof (SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _player;

    public float Damage => _damage;

    private void Start()
    {
        SetEnemyData();
    }

    private void Update()
    {
        GoTowardsPlayer();
        TurnOnPlayer();
    }

    private void SetEnemyData()
    {
        GetComponent<EnemyHealth>().SetHealth(_enemyData.healthPoints, _enemyData.healthPoints);
        _speed = _enemyData.speed;
        _damage = _enemyData.damage;
        _name = _enemyData.name;
        _sprite = _enemyData.sprite;
    }

    private void GoTowardsPlayer()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) > _maxDistance)
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void TurnOnPlayer()
    {
        GetComponent<SpriteRenderer>().flipX = transform.position.x - _player.transform.position.x < 0.0f;
    }
}
