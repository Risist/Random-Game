using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourRotateToAim : AiBehaviourBase
{
	public bool update = true;
	public AiLocationBase aim;
	Rigidbody2D body;

	protected new void Start()
	{
		base.Start();
		body = GetComponentInParent<Rigidbody2D>();
	}

	public override bool PerformAction()
	{
		if (update)
		{
			Vector2 directionOfMove = aim.GetLocation() - body.position;
			body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1);
		}
		return true;
	}

	public override void EnterAction()
	{
		base.EnterAction();
		Vector2 directionOfMove = aim.GetLocation() - body.position;
		body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1);
	}
}
