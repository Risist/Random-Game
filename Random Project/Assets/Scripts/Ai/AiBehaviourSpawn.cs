using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviourSpawn : ArmyBehaviourBase
{
	/// object to spawn 
	public GameObject prefab;
	/// where to spawn
	public Transform spawnPoint;
	/// in what delay from beggining of animation
	public Timer delay;
	/// how much casts of the ability left
	/// -1 means infinite ammo
	public int leftCast = -1;

	public override bool PerformAction()
	{
		if(delay.isReady())
		{
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			--leftCast;
			return true;
		}

		return base.PerformAction();
	}
	public override float GetUtility(string orderCode)
	{
		if (leftCast == 0)
			return 0;

		return base.GetUtility(orderCode);
	}

	public override void EnterAction()
	{
		delay.restart();
		base.EnterAction();
	}
}
