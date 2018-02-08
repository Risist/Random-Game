using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomPitch : MonoBehaviour {

	public float pitchMin = 1.0f;
	public float pitchMax = 1.0f;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().pitch = Random.Range(pitchMin, pitchMax);
		Destroy(this);
	}
}
