using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUpgradePickup : MonoBehaviour {

	public float energyMaxBonus;
	public float energyActualBonus;
	public float energyBonusRegen;

	public bool antidotum = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			var energy = collision.GetComponent<Weapon>();
			energy.maximumAmmo += energyMaxBonus;
			energy.ammoRegeneration += energyBonusRegen;
			energy.ammo += energyActualBonus;

			if (antidotum && energy.ammoRegeneration < 0)
				energy.ammoRegeneration = 0;

			Destroy(gameObject);
		}

	}

}
