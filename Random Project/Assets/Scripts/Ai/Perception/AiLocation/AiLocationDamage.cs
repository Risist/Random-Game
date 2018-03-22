using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationDamage : AiLocationBase {

	[Range(0.0f, 1.0f)]
	public float damping;
	public float minimalDamage = 10.0f;

	float damageAccumulator = 0.0f;
	AiPerceiveUnit currentUnit = null;
	GameObject currentObject;

	Vector2 lastPosition;

	public override AiPerceiveUnit GetTarget()
	{
		return currentUnit;
	}
	public override GameObject GetTargetObject()
	{
		return currentObject;
	}
	public override Vector2 GetLocation()
	{
		if (currentObject)
			lastPosition = currentObject.transform.position;
		return base.GetLocation() + lastPosition;
	}
	public override bool IsValid()
	{
		return (damageAccumulator > minimalDamage) && base.IsValid();
	}

	/// ///////////////////////////


	private void FixedUpdate()
	{
		damageAccumulator *= damping;
	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if (!data.causer)
			return;

		if (data.causer == currentObject)
			damageAccumulator -= data.damage.toFloat();
		else if(-data.damage.toFloat() > damageAccumulator)
		{
			damageAccumulator = -data.damage.toFloat();
			currentObject = data.causer;
			currentUnit = data.causer.GetComponentInParent<AiPerceiveUnit>();
			lastPosition = currentObject.transform.position;
		}
	}
}
