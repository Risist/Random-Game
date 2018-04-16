using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSkillAnimation : WeaponBase {
	
	public string triggerEvent = "slash";
	public Animator animManager;

	void Update ()
	{
        if (CastSkill())
		{
            PlayAnimation();
            PlaySound();
			if (movement)
				movement.ApplyRotationToMouse();
		}
	}

    protected void PlayAnimation()
    {
        if (animManager)
            animManager.SetTrigger(triggerEvent);
    }


}
