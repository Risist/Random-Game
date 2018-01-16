using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventDealDmg : MonoBehaviour {

	public float radius;
	public SimpleDamage dmg;
	public string ignoreTag = "noTag";

	void OnDeath()
	{
		var list = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (var it in list)
		{
			HealthController hp = it.gameObject.GetComponent<HealthController>();
			if (hp && it.tag != ignoreTag)
			{
				hp.DealDamage(dmg, gameObject);
			}
		}
	}
}
