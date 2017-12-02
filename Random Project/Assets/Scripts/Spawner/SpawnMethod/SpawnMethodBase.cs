using UnityEngine;
using System.Collections;

public abstract class SpawnMethodBase : MonoBehaviour {

    public SpawnListBase spawnList;

	// Use this for initialization
	public void Start () {
        if (spawnList == null)
            spawnList = GetComponent<SpawnListBase>();
	}
}
