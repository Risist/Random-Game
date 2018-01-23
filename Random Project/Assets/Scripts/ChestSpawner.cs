using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : SpawnMethodBase {

	public string animCode = "open";
	public string objectTag = "Player";
	public int nSpawnMin;
	public int nSpawnMax;
	public bool remove = false;

	bool oppened = false;
	bool spawned = false;
	public Timer tSpawn;

	private void Update()
	{
		if(oppened)
		{
			if(!spawned && tSpawn.isReady())
			{
				int n = Random.Range(nSpawnMin, nSpawnMax);
				for (int i = 0; i < n; ++i)
					spawnList.Spawn();

				spawned = true;

				if (remove)
					Destroy(gameObject);
			}
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if( !oppened && collision.gameObject.tag == objectTag )
		{
			var v = GetComponent<Animator>();
			if (v)
				v.SetTrigger(animCode);

			oppened = true;
			tSpawn.restart();
		}
	}
}
