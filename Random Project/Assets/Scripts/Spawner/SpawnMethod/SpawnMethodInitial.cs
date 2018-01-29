using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodInitial : SpawnMethodBase {

	public bool destroy = true;
	public GameObject objToRemove;
	public int nSpawnMin = 1;
	public int nSpawnMax = 1;

	// Use this for initialization
	void Update () {
		int n = Random.Range(nSpawnMin, nSpawnMax);
		for (int i = 0; i < n; ++i)
			spawnList.Spawn();
		if (destroy)
		{
			if (objToRemove)
				Destroy(objToRemove);
			else
				Destroy(gameObject);
		}
		else Destroy(this);

	}
}
