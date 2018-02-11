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

	public override bool PerformAction()
	{
		if(delay.isReady())
		{
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			return true;
		}

		return false;
	}

	public override void EnterAction()
	{
		delay.restart();
		base.EnterAction();
	}
}
