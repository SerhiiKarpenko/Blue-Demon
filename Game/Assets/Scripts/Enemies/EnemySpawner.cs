using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[System.Serializable]
	public class EnemiesToSpawn
	{
		public GameObject EnemyPrefab;
		public int Amount;
		public float TimeBetweenThisTypeOfEnemySpawning;
		public float TimeBetweenWave;
	}

	[SerializeField] private List<EnemiesToSpawn> _enemiesToSpawn;
	[SerializeField] private Transform[] _enemySpawnPositions;
	[SerializeField] private float _timeBeforeEmeiesSpawning;
	[SerializeField] private PlayerLevel _playerLevel;

	private void Start()
	{
		StartCoroutine(BatSpawner());
		StartCoroutine(FireBallSpawner());
	}
	

	private Vector3 SetSpawnPosition(Transform[] enemySpawnPositions)
	{
		Transform enemySpawnPos = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Length)];
		return enemySpawnPos.position;
	}
	

	private IEnumerator BatSpawner()
	{
		yield return new WaitForSeconds(_timeBeforeEmeiesSpawning);
		while (true)
		{
			_enemiesToSpawn[0].Amount = _playerLevel.CurrentLevel;
			for (int j = 0; j < _enemiesToSpawn[0].Amount; j++)
			{
				EnemiesList.Instance.Enemies.Add(Instantiate(_enemiesToSpawn[0].EnemyPrefab, SetSpawnPosition(_enemySpawnPositions), Quaternion.identity));
				yield return new WaitForSeconds(_enemiesToSpawn[0].TimeBetweenThisTypeOfEnemySpawning);
			}

			yield return new WaitForSeconds(_enemiesToSpawn[0].TimeBetweenWave);
		}
	}

	private IEnumerator FireBallSpawner()
    {
		yield return new WaitForSeconds(_timeBeforeEmeiesSpawning);
		while (true)
        {
			_enemiesToSpawn[1].Amount = _playerLevel.CurrentLevel - 3;
			if (_enemiesToSpawn[1].Amount > 0)
			{
				for (int i = 0; i < _enemiesToSpawn[1].Amount; i++)
				{
					EnemiesList.Instance.Enemies.Add(Instantiate(_enemiesToSpawn[1].EnemyPrefab, SetSpawnPosition(_enemySpawnPositions), Quaternion.identity));
					yield return new WaitForSeconds(_enemiesToSpawn[1].TimeBetweenThisTypeOfEnemySpawning);
				}
			}
			yield return new WaitForSeconds(_enemiesToSpawn[1].TimeBetweenWave);
        }
    }

}