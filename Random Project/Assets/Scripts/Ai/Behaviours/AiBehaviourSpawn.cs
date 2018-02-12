using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourSpawn : AiBehaviourBase
{
	/// object to spawn 
	public GameObject prefab;
	/// where to spawn
	public Transform spawnPoint;
	/// in what delay from beggining of animation
	public Timer delay;

	bool bSpawned;

	public override bool PerformAction()
	{
		if (!bSpawned && delay.isReady())
		{
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			bSpawned = true;
		}
		return bSpawned;
	}

	public override void EnterAction()
	{
		delay.restart();
		bSpawned = false;
		base.EnterAction();
	}
}
