using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourRotateTo : AiBehaviourBase {

	public AiLocationBase aim;
	public bool update = true;
	public float rotationSpeed;
	AiMovement movement;

	protected new void Start()
	{
		base.Start();
		movement = GetComponentInParent<AiMovement>();
	}
	public override bool PerformAction()
	{
		if (update)
		{
			movement.applyInfluencePointRotation(aim.GetLocation(), rotationSpeed);
		}
		return true;
	}

	public override void EnterAction()
	{
		base.EnterAction();
		if (!update)
		{
			movement.SetRotationPoint(aim.GetLocation());
		}
	}

}
