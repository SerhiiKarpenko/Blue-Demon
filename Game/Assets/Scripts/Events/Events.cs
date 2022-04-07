using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Events : MonoBehaviour
{
	public static event Action PlayerDied;

	public static void OnPlayerDeath()
	{
		PlayerDied?.Invoke();
	}


}
