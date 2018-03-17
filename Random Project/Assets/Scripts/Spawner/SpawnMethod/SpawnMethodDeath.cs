using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodDeath : SpawnMethodBase {

	public int nObjectsToSpawnMin=1;
	public int nObjectsToSpawnMax=1;
	bool dead = false;

	void OnDeath(HealthController.DamageData data)
	{
		if (dead)
			return;

		int n = Random.Range(nObjectsToSpawnMin, nObjectsToSpawnMax);
		for(int i = 0; i < n; ++i)
			spawnList.Spawn();

		dead = true;
	}
}
