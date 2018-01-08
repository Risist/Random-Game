using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public string weaponType;
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

		//Debug.Log("ammo = " + ammo);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		/// ammo consuming
		WeaponShard shard = collision.gameObject.GetComponent<WeaponShard>();
		if (shard && shard.weaponType == weaponType && gameObject.tag == "Player")
		{
			gainAmmo(shard.ammoGain);
			Destroy(collision.gameObject);
		}
	}
}
