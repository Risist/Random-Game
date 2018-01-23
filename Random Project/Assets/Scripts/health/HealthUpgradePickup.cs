using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradePickup : MonoBehaviour
{
	public float healthMaxBonus;
	public float healthActualBonus;
	public float healthBonusRegen;

	public bool antidotum = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var hp = collision.GetComponent<HealthController>();
			hp.max += healthMaxBonus;
			hp.regeneration += healthBonusRegen;
			hp.DealDamage(healthActualBonus, gameObject);

			if (antidotum && hp.regeneration < 0)
				hp.regeneration = 0;
			
			Destroy(gameObject);
		}

	}

}
