using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReduction : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float damageReduction = 1.0f;

	HealthController controller;
	private void Start()
	{
		controller = GetComponentInParent<HealthController>();
	}

	void OnReceiveDamage(HealthController.DamageData data)
	{
		if(enabled && data.causer != gameObject)
		{
			controller.DealDamage(-data.damage.toFloat()*damageReduction, gameObject);
		}
	}
}
