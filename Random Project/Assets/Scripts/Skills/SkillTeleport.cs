using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTeleport : MonoBehaviour {

	GameObject player;
	public Timer cd;
    public string playerTag = "Player";

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(playerTag);
		cd.restart();
	}
	
	// Update is called once per frame
	void Update () {
		if(cd.isReady())
		{
			if(player)
				player.transform.position = transform.position;
			Destroy(gameObject);
		}
	}
}
