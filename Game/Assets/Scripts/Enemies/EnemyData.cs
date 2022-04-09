using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public float HealthPoints;
    public float Damage;
    public float Speed;
    public float AmountexperienceToDrop;
    public string Name;
    public Sprite sprite;
}