using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestRandomNavMovement : MonoBehaviour
{
	public float radius;
	public Timer timer;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 v = transform.position + Random.insideUnitSphere * radius;
		v.y = 0;
		if (timer.isReadyRestart())
			agent.SetDestination(v);
	}
}
