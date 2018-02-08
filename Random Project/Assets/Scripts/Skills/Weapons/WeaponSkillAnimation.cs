using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkillAnimation : WeaponBase {
	
	public string triggerEvent = "slash";
	public Animator animManager;
	public bool initialRotationToMouse = true;

	void Update ()
	{
		if (Input.GetButton(buttonCode) && CastSkill())
		{
			if (animManager)
				animManager.SetTrigger(triggerEvent);
			PlaySound();
			if (initialRotationToMouse && movement)
				movement.applyRotationToMouse();

		}
	}
}
