using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnData : MonoBehaviour {

	public GameObject dyingObjectPrefab;

	public void Respawn()
	{
		Instantiate(dyingObjectPrefab, transform.position, transform.rotation);
	}
}
