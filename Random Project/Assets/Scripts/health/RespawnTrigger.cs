using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

	public Timer timeRespawn;
	public float radius;
	bool respawned = false;

	private void Start()
	{
		timeRespawn.restart();	
	}
	private void Update()
	{

		/*if (!timeRespawn.isReady() || respawned)
			return;

		respawned = true;

		var list = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (var it in list)
		{
			var respawnData = it.GetComponent<RespawnData>();
			if (respawnData)
			{
				respawnData.Respawn();
				Destroy(respawnData.gameObject);
			}
		}*/
	}
}
