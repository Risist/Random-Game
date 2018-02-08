using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
	public EnergyController resource;
	public float cost;

	public string buttonCode = "Fire1";
	public Timer cd = new Timer(0.5f);
	public new AudioSource audio;

	public PlayerMovement movement;
	public string displayName;
	public string description;


	protected void PlaySound()
	{
		if (audio)
			audio.Play();
	}
	protected bool CastSkill()
	{
		if (cd.isReady() && resource.Spend(cost) )
		{
			cd.restart();
			return true;
		}
		return false;
	}
}
