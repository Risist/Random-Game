using UnityEngine;
using System.Collections;


/// spawns an object from spawn list every some time between min and max
public class SpawnMethodOverTime : SpawnMethodBase {

    public float cdMin = 0;
    public float cdMax = 1;
    public Timer timer;

	// Use this for initialization
	new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        if(timer.isReadyRestart())
        {
            timer.cd = Random.Range(cdMin, cdMax);

            spawnList.Spawn();
        }
	}
}
