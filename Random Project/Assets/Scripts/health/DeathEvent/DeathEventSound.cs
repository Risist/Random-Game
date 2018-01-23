using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DeathEventSound : MonoBehaviour {

	public AudioClip audioClip;
	public float pitchBase = 1.0f;
	public float pitchDmgScale = 0.0f;
	public float pitchRandom = 0.0f;
	public float volumeBase = 1.0f;
	public float volumeDmgScale = 0.0f;
	public float volumeRandom = 0.0f;

	bool died = false;

	// Use this for initialization
	void Start () {
		died = false;
	}

	void OnDeath(HealthController.DamageData data)
	{
		if (died)
			return;
		died = true;

		AudioManager.inst.CreateInstance(audioClip, transform.position,
			volumeBase + (-data.damage.toFloat()) * volumeDmgScale + (Random.value - 0.5f) * 2.0f * volumeRandom,
			pitchBase + (-data.damage.toFloat()) * pitchDmgScale + (Random.value - 0.5f) * 2.0f * pitchRandom
			);
	}
}
