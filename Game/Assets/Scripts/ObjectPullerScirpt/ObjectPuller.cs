using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour
{
	[System.Serializable]
	public class Pool
	{
		public string Tag;
		public GameObject Prefab;
		public int Size;

		public Pool(string tag, GameObject prefab, int size)
        {
			Tag = tag;
			Prefab = prefab;
			Size = size;
        }

        
	}

    #region Singleton
    public static ObjectPuller Instance;
    private void Awake()
    {
		Instance = this;
    }
    #endregion

    [SerializeField] private List<Pool> _pools;
	[SerializeField] private Dictionary<string, Queue<GameObject>> _poolDictionary;

	private void Start()
	{
		_poolDictionary = new Dictionary<string, Queue<GameObject>>();
		foreach(Pool pool in _pools)
		{
			Queue<GameObject> objectPool = new Queue<GameObject>();
			for(int i = 0; i < pool.Size; i++)
			{
				GameObject obj = Instantiate(pool.Prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			_poolDictionary.Add(pool.Tag, objectPool);
		}
	}

	
	public GameObject SpawnObjectFromPool(string tag, Vector3 spawnPosition, Quaternion spawnRotation)
	{
		if (!_poolDictionary.ContainsKey(tag))
		{
			throw new System.Exception("Pool with tag :" + tag + " doesnt excist");
		}
		GameObject objectToSpawn = _poolDictionary[tag].Dequeue();
		objectToSpawn.SetActive(true);
		objectToSpawn.transform.position = spawnPosition;
		objectToSpawn.transform.rotation = spawnRotation;
		_poolDictionary[tag].Enqueue(objectToSpawn);
		return objectToSpawn;
	}

	public void SetNewSizeToPool(string tag, int size)
    {
		foreach(Pool pool in _pools)
        {
			if(pool.Tag == tag)
            {
				pool.Size = size;
            }
        }
    }
}
