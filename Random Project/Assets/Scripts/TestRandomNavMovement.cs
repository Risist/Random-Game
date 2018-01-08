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
		//agent.Move()

		Vector2 v = Random.insideUnitCircle * radius;
		if (timer.isReadyRestart())
			agent.SetDestination( new Vector3( transform.position.x + v.x, transform.position.y + v.y, transform.position.z) );
	}
}
