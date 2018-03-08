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

	public bool updateRotation;

	public override bool PerformAction()
	{
		//movement.applyInfluencePointRotation(aim.GetLocation(), rotationSpeed);
		movement.applyInfluencePoint(aim.GetLocation(), movementSpeed, rotationSpeed, stopDistance);

		return true;

		/*Vector2 directionOfMove = aim.GetLocation() - body.position;
		body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1);

		if (directionOfMove.sqrMagnitude > stopDistance * stopDistance)
			bShouldMove = true;
		else if (returnArrived)
			return true;

		return !returnArrived;*/
	}
}