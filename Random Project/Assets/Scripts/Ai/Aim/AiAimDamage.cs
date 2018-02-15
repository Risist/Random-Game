using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAimDamage : AiAimBase
{
	public float minOffset;
	public float maxOffset;

	Vector2 lastDestination;

	protected new void Start()
	{
		base.Start();
		lastDestination = (Vector2)transform.position + Random.insideUnitCircle * Random.Range(minOffset, maxOffset);
	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if(data.causer)
			lastDestination = (Vector2)data.causer.transform.position + Random.insideUnitCircle * Random.Range(minOffset, maxOffset);
	}

	public override Vector2 GetAimPoint()
	{
		return lastDestination;
	}
}
