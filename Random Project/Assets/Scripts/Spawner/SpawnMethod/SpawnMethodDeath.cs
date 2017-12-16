using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodDeath : SpawnMethodBase {

	public int nObjectsToSpawnMin=1;
	public int nObjectsToSpawnMax=1;

	void OnDeath(HealthController.DamageData data)
	{
		int n = Random.Range(nObjectsToSpawnMin, nObjectsToSpawnMax);
		for(int i = 0; i < n; ++i)
			spawnList.Spawn();
	}
}
