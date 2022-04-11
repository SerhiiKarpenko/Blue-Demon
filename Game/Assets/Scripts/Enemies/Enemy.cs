using UnityEngine;

[RequireComponent(typeof (EnemyHealth))]
[RequireComponent(typeof (SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _amountOfExperienceToDrop;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _player;

    public float Damage => _damage;
    public float AmountOfExperienceToDrop => _amountOfExperienceToDrop;


    private void Awake()
    {
        SetEnemyData();
        Debug.Log(_amountOfExperienceToDrop);
    }

    private void Start()
    {
        _player = PlayerInstance.Instance.gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        GoTowardsPlayer();
        TurnOnPlayer();
    }

    private void SetEnemyData()
    {
        GetComponent<EnemyHealth>().SetHealth(_enemyData.HealthPoints, _enemyData.HealthPoints);
        _amountOfExperienceToDrop = _enemyData.AmountexperienceToDrop;
        _speed = _enemyData.Speed;
        _damage = _enemyData.Damage;
        _name = _enemyData.Name;
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
