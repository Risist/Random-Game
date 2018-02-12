using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourMoveTo : AiBehaviourMotor
{

	public AiAimBase aim;
	public float stopDistance;
	public bool returnArrived = false;

	public override bool PerformAction()
	{
		Vector2 directionOfMove = aim.GetAimPoint() - body.position;
		body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1);

		if (directionOfMove.sqrMagnitude > stopDistance * stopDistance)
			bShouldMove = true;
		else if (returnArrived)
			return true;

		return !returnArrived;
	}
}