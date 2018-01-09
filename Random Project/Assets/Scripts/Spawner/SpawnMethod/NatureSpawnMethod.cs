using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawnMethod : SpawnMethodBase {

	public bool remove;
	public Transform aim;
	public float endDistance;
	public float spawnDist;
	public Vector2 influencePosition;
	
	// Update is called once per frame
	void Update () {

		Vector2 position = transform.position;

		while((transform.position - aim.position).sqrMagnitude > endDistance * endDistance)
		{
			Vector2 toAim = -(transform.position - aim.position).normalized * spawnDist;
			var obj = spawnList.Spawn(toAim, 0);
			transform.position = obj.transform.position + (Vector3)influencePosition;
		}

		transform.position = position;

		if (remove)
			Destroy(gameObject);
		else
			Destroy(this);
	}
}
