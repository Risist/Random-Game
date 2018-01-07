using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodSkill : SpawnMethodBase {

	public Weapon weapon;

	public float ammoCost;
	public string buttonCode = "Fire1";
	public Timer timer = new Timer(0.5f);
	bool ahouldShoot = false;

	public AnimationManager animManager;

	// Update is called once per frame
	void Update () {


		if (ahouldShoot)
		{
			spawnList.Spawn();
			ahouldShoot = false;
		}

		if (Input.GetButton(buttonCode))
		{
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
