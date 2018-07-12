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
		//movement.ApplyInfluencePoint(aim.GetLocation(), movementSpeed, rotationSpeed, stopDistance);

		Vector2 point = aim.GetLocation();
		Vector2 inf = (point - (Vector2)movement.transform.position);

		float sqMag = inf.sqrMagnitude;
		inf.Normalize();
        if (sqMag > stopDistance * stopDistance)
			movement.ApplyInfluencePosition( inf * movementSpeed );

		movement.ApplyInfluenceRotation(inf * rotationSpeed);

		return true;
	}

}