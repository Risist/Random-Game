using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourRotateTo : AiBehaviourBase {

	public AiAimBase aim;
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
			Debug.Log("at rotation update");
			movement.applyInfluencePointRotation(aim.GetAimPoint(), rotationSpeed);
		}
		return true;
	}

	public override void EnterAction()
	{
		base.EnterAction();
		if (!update)
		{
			movement.SetRotationPoint(aim.GetAimPoint());
		}
	}

}
