﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceActivate : MonoBehaviour {

	public float activationDistance;
	GameObject[] objs;
	Transform player;

	Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
		int childCount = _transform.childCount;

		objs = new GameObject[childCount];
		for (int i = 0; i < childCount; ++i)
		{
			objs[i] = _transform.GetChild(i).gameObject;
			objs[i].SetActive(false);
		}

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if( player && ((Vector2)_transform.position - (Vector2)player.position).sqrMagnitude < activationDistance*activationDistance)
		{
			foreach (var it in objs)
				it.SetActive(true);
			Destroy(this);
		}
	}
}