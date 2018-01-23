using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : WeaponBase
{
	public AnimationManager animManager;
	public GameObject prefab;
	bool ahouldShoot = false;

	// Use this for initialization
	void Start()
	{
		if (!weapon)
			weapon = GetComponent<Weapon>();
	}

	// Update is called once per frame
	void Update()
	{
		if(ahouldShoot)
		{
			if (movement)
			{

				movement.applyRotationToMouse();
			}
			PlaySound();
			Instantiate(prefab, transform.position, transform.rotation);
			ahouldShoot = false;
		}

		if (Input.GetButton(buttonCode) )
		{
			if (movement)
			{
				movement.applyRotationToMouse();
			}
			if (timer.isReady() && weapon.UseAmmo(ammoCost))
			{
				ahouldShoot = true;
				timer.restart();
			}

			if (animManager)
				animManager.CastAnimation();
		}
	}
}
