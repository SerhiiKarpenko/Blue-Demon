using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    public static EnemiesList Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> Enemies;
}
