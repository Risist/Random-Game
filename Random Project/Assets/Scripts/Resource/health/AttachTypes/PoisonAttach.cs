using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttach : AttachBase
{
	public Timer applyCd;
	public SimpleDamage damage;
	HealthController parentHealth;

	protected new void Start()
	{
		base.Start();
		parentHealth = transform.parent.GetComponent<HealthController>();
	}

	protected new void Update()
	{
		if(applyCd.isReadyRestart())
		{
			parentHealth.DealDamage(damage, gameObject);
		}
		base.Update();
	}
}
