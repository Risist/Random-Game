using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiConditionDamage : AiConditionBase {

	public float damageScale;
	[Range(0.0f, 1.0f)]
	public float damageDamping = 1.0f;
	float storedDamage = 0;

	void OnReceiveDamage(HealthController.DamageData data)
	{
		storedDamage += data.damage.toFloat();
	}

	public override float GetUtility()
	{
		//Debug.Log(base.GetUtility() - storedDamage * damageScale);
		return base.GetUtility() - storedDamage * damageScale;
	}

	private void FixedUpdate()
	{
		storedDamage *= damageDamping;
	}

}
