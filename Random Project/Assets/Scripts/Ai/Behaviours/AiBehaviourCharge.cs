using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourCharge : AiBehaviourBase {

	public AiAimBase aim;
	public float movementSpeed;

	public override void EnterAction()
	{
		base.EnterAction();
		var animator = GetComponentInParent<Animator>();
		Vector2 aimPos = aim.GetAimPoint();
		animator.SetFloat("aimX", aimPos.x);
		animator.SetFloat("aimY", aimPos.y);
		animator.SetFloat("speed", movementSpeed);
	}

	/*AiMovement movement;

	Vector2 d;
	public new void Start()
	{
		base.Start();
		movement = GetComponentInParent<AiMovement>();
	}

	public override bool PerformAction()
	{
		movement.applyInfluencePosition(d * movementSpeed);
		return true;
	}

	public override void EnterAction()
	{
		base.EnterAction();
		d = aim.GetAimPoint();
		movement.SetRotationPoint(d);
		d = d - (Vector2)transform.position;
		d.Normalize();
	}*/
}
