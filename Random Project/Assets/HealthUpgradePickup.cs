using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradePickup : MonoBehaviour
{
	public float healthMaxBonus;
	public float healthActualBonus;
	public float healthBonusRegen;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var hp = collision.GetComponent<HealthController>();
			hp.max += healthMaxBonus;
			hp.regeneration += healthBonusRegen;
			hp.actual += healthActualBonus;

			Destroy(gameObject);
		}

	}

}
