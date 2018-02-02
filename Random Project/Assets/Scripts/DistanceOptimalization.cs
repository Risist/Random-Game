using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceOptimalization : MonoBehaviour {

	public float distanceMidificator;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().addToActivationList(this);
	}
}
