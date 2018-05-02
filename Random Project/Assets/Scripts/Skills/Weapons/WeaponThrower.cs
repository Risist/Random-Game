using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Plays animation and after given delay spawns provided prefab
 * Applies rotation to mouse after casting skill over given time period
 */
public class WeaponThrower : WeaponThrowerFreeze
{
    //public Timer rotationApplyTime = new Timer(0);

    protected void Update()
    {
        if (CastSkill())
        {
            PlayAnimation();
            PlaySound();

            if (movement)
            {
                rotationApplyTime.restart();
            }

            shootDelay.restart();
            shouldShoot = true;
        }
    }

    new protected void LateUpdate()
    {
        if (!rotationApplyTime.isReady())
        {
            movement.ApplyRotationToMouse();
        }

        if (shouldShoot && shootDelay.isReady())
        {
            Instantiate(prefab, _transform.position, _transform.rotation);
            shouldShoot = false;
        }
    }
}


/*
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
}*/
