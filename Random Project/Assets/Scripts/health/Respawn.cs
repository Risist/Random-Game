using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	
	public int leftRespawns;
	GameObject player;
	
	public void respawn()
	{
		if (leftRespawns > 0)
		{
			leftRespawns--;

			//player.
		}
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
