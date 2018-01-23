using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeAudio : MonoBehaviour {

	public AudioClip audioClip;
	public float pitchBase = 1.0f;
	public float pitchRandom = 0.0f;
	public float volumeBase = 1.0f;
	public float volumeRandom = 0.0f;

	// Use this for initialization
	void Start () {
		AudioManager.inst.CreateInstance(audioClip, transform.position,
			volumeBase + (Random.value - 0.5f) * 2.0f * volumeRandom,
			pitchBase + (Random.value - 0.5f) * 2.0f * pitchRandom
		);
	}
}
