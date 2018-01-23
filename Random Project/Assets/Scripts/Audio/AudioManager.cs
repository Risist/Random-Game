using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public static AudioManager inst;
	public int nAudioCanals;
	public GameObject audioPrefab;
	AudioSource[] sources;

	public bool CreateInstance(AudioClip clip, Vector2 position, float volume = 1.0f, float pitch = 1.0f)
	{
		foreach(var it in sources)
			if(!it.isPlaying)
			{
				it.pitch = pitch;
				it.volume = volume;
				it.clip = clip;
				it.transform.position = position;

				it.Play();
				return true;
			}

		return false;
	}



	private void Start()
	{
		inst = this;
		sources = new AudioSource[nAudioCanals];
		for (int i = 0; i < sources.Length; ++i)
		{
			var it = sources[i] = Instantiate(audioPrefab).GetComponent<AudioSource>();
			it.loop = false;
			it.playOnAwake = false;
			it.outputAudioMixerGroup = AudioMixerGroup.FindObjectOfType<AudioMixerGroup>();
		}
	}
}
