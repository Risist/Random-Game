using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourMoveTo : AiBehaviourBase
{
	AiMovement movement;

	new protected void Start()
	{
		base.Start();
		movement = GetComponentInParent<AiMovement>();
	}

	public AiLocationBase aim;
	public float stopDistance;

	public float rotationSpeed;
	public float movementSpeed;

	public override bool PerformAction()
	{

		//movement.ApplyInfluencePointRotation(aim.GetLocation(),  rotationSpeed);
		//movement.SetRotationPoint(aim.GetLocation());
		movement.ApplyInfluencePoint(aim.GetLocation(), movementSpeed, rotationSpeed, stopDistance);

		return true;
	}
}