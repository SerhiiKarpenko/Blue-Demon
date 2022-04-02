using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public float healthPoints;
    public float damage;
    public float speed;
    public float experienceToDrop;
    public string name;
    public Sprite sprite;
}