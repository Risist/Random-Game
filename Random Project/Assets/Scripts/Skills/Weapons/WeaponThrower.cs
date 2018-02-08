using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * used in a few contexts:
 *	- rotate the player to mouse direction and freeze rotation for a period of time
 *	- rotate the player to mouse direction for the whole time the button is pressed
 *	- 
 */
public class WeaponThrower : WeaponBase
{
	public AnimationManager animManager;
	public bool animateWhenReadyOnly = false;
	public GameObject prefab;

	public bool freezeRotation = false;
	public Timer shootDelay = new Timer(0);
	public Timer rotationApplyTime = new Timer(0);

	float lastRotation;
	bool ahouldShoot = false;

	// Update is called once per frame
	void Update()
	{
		if(freezeRotation)
		{
			if (movement && !rotationApplyTime.isReady())
			{
				movement.applyExternalRotation(lastRotation);

				if (animManager && !animateWhenReadyOnly)
					animManager.CastAnimation();
			}
			if (Input.GetButton(buttonCode))
			{

				if ((!animManager || animManager.CanCastAnimation()) && CastSkill())
				{
					if (movement)
						lastRotation = movement.applyRotationToMouse();

					if (animManager)
						animManager.CastAnimation();

					PlaySound();

					ahouldShoot = true;
					shootDelay.restart();
					rotationApplyTime.restart();
				}

			}
		}else if (Input.GetButton(buttonCode))
		{
			if (movement)
				movement.applyRotationToMouse();

			if ((!animManager || animManager.CanCastAnimation()) && CastSkill())
			{

				if (animManager)
					animManager.CastAnimation();

				PlaySound();

				ahouldShoot = true;
				shootDelay.restart();
			}

			if (animManager && !animateWhenReadyOnly)
				animManager.CastAnimation();
		}
	}

	void LateUpdate()
	{
		if(ahouldShoot && shootDelay.isReady())
		{
			Instantiate(prefab, transform.position, transform.rotation);
			ahouldShoot = false;
		}
	}
}
