using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float ammo;
	public float maximumAmmo;
	public float ammoRegeneration;

	void Update()
	{
		gainAmmo(ammoRegeneration * Time.deltaTime);
	}

	public bool HasEnoughAmmo(float required)
	{
		return required < ammo;
	}
	public bool UseAmmo(float required)
	{
		if(HasEnoughAmmo(required))
		{
			ammo -= required;
			return true;
		}
		return false;
	}

	public void gainAmmo(float bonus)
	{
		ammo = Mathf.Clamp(ammo + bonus, 0, maximumAmmo);
	}
}
