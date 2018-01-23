using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventSpawnBlood : MonoBehaviour {

	public GameObject bloodPrefab;
	public GameObject respawnPrefab;

	void OnDeath(HealthController.DamageData data)
	{
		var blood = Instantiate(bloodPrefab, transform.position, transform.rotation);
		var respData = blood.AddComponent<RespawnData>();
		respData.dyingObjectPrefab = respawnPrefab;
	}
}
