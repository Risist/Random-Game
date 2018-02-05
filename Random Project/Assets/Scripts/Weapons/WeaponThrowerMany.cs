using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowerMany : WeaponBase
{
	public AnimationManager animManager;
	public bool animateWhenReadyOnly = false;
	[System.Serializable]
	public class SpawnStruct
	{
		public GameObject prefab;
		public Transform transform;
	}
	public SpawnStruct[] spawns;

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
			foreach(var it in spawns)
				Instantiate(it.prefab, it.transform.position, it.transform.rotation);
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

				if (animManager)
					animManager.CastAnimation();
			}

			if (animManager && !animateWhenReadyOnly)
				animManager.CastAnimation();
		}
	}
}
