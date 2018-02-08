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
	public bool freezeRotation = false;
	public Timer shootDelay = new Timer(0);
	public Timer rotationApplyTime = new Timer(0);
	float lastRotation;
	bool ahouldShoot = false;

	// Update is called once per frame
	void Update()
	{
		if (freezeRotation)
		{
			if (movement && !rotationApplyTime.isReady())
				movement.applyExternalRotation(lastRotation);

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

				if (animManager && !animateWhenReadyOnly)
					animManager.CastAnimation();
			}
		}
		else if (Input.GetButton(buttonCode))
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
		if (ahouldShoot && shootDelay.isReady())
		{
			foreach (var it in spawns)
				Instantiate(it.prefab, it.transform.position, it.transform.rotation);
			ahouldShoot = false;
		}
	}
}
