using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakePush : MonoBehaviour {

	public float powerMin = 0;
	public float powerMax = 1;
	public bool randomRotation = true;

	// Use this for initialization
	void Start () {
		if(randomRotation)
			GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * Random.Range(powerMin, powerMax));
		else
			GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(powerMin, powerMax));
	}
}
