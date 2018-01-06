using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodCollision : SpawnMethodBase {

	private void OnCollisionEnter2D(Collision2D collision)
	{
		spawnList.Spawn();
	}
}
