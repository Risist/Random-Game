using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventDealDmg : MonoBehaviour {

	public float radius;
	public SimpleDamage dmg;

	void OnDeath()
	{
		var list = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (var it in list)
		{
			HealthController hp = it.gameObject.GetComponent<HealthController>();
			if (hp)
			{
				hp.DealDamage(dmg, gameObject);
			}
		}
	}
}
