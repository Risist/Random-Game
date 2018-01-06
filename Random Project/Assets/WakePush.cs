using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakePush : MonoBehaviour {

	public float powerMin = 0;
	public float powerMax = 1;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * Random.Range(powerMin, powerMax));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
