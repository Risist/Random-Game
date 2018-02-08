using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventUi : MonoBehaviour {

	public GameObject ui;

	void OnDeath(HealthController.DamageData data)
	{
		ui.SetActive(true);
	}
}
