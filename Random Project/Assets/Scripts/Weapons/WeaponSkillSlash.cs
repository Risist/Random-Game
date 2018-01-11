using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkillSlash: WeaponBase {
	
	public string triggerEvent = "slash";
	public AnimationManager animManager;
	bool ahouldShoot = false;

	// Use this for initialization
	void Start () {
		if (!weapon)
			weapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton(buttonCode))
		{
			
			if (timer.isReady() && weapon.UseAmmo(ammoCost))
			{
				if (movement)
					movement.applyRotationToMouse();
				if (animManager)
					animManager.animator.SetTrigger(triggerEvent);
				timer.restart();
				ahouldShoot = true;
			}
		}
	}
}
