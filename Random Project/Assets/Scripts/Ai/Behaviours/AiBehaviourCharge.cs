using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourCharge : AiBehaviourBase {

	public AiLocationBase aim;
	public float movementSpeed;

	public override void EnterAction()
	{
		base.EnterAction();
		var animator = GetComponentInParent<Animator>();
		Vector2 aimPos = aim.GetLocation();
		animator.SetFloat("aimX", aimPos.x);
		animator.SetFloat("aimY", aimPos.y);
		animator.SetFloat("speed", movementSpeed);
	}
}
