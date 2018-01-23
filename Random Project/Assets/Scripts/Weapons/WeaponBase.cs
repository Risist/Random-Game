using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
	public Weapon weapon;

	public float ammoCost;
	public string buttonCode = "Fire1";
	public Timer timer = new Timer(0.5f);
	public new AudioSource audio;

	public PlayerWSADMovement movement;
	public string displayName;


	protected void PlaySound()
	{
		if (audio)
			audio.Play();
	}
}
