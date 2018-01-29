using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventHard : MonoBehaviour {

	public int increaseRoomsOpen = 1;

	void OnDeath(HealthController.DamageData data)
	{
		var gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		gm.increaseRoomsOpen(increaseRoomsOpen);
	}
}
