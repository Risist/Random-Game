using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * script responsible for dealing with upgrade bonuses of Fate's
 */
public class FateUpgrader : MonoBehaviour {

	public float maxHpBonus;
	public float regHpBonus;
	public float maxEnergyBonus;
	public float regEnergyBonus;
	public float movementSpeedBonus;
	public float xpGainBonus;

	public void OnLvlUpFate(ProgressionManager.Fate fate)
	{
		switch(fate.name)
		{
		case "Melee":
			{
				GetComponent<HealthController>().max += maxHpBonus;
				break;
			}
		case "Hunter":
			{
				GetComponent<PlayerMovement>().movementSpeed += movementSpeedBonus;
				break;
			}
		case "Devil":
			{
				GetComponent<EnergyController>().max += maxEnergyBonus;
				break;
			}
		case "Wind":
			{
				GetComponent<EnergyController>().regeneration += regEnergyBonus;
				break;
			}
		case "Earth":
			{
				GetComponent<HealthController>().regeneration += regHpBonus;
				break;
			}
		case "Void":
			{
				fate.manager.requiredXpBase -= xpGainBonus;
				break;
			}
		}
	}
}
