using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodCollision : SpawnMethodBase {

	public Timer cdSpawn = new Timer(0);

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(cdSpawn.isReadyRestart())
			spawnList.Spawn();
	}
}
