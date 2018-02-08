using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviourRotateToAim : ArmyBehaviourBase
{
	public Rigidbody2D body;
	public bool update = true;
	public float aimOffsetMin = 0.0f;
	public float aimOffsetMax = 0.0f;
	public float addictionalRotation = 180;
	Vector2 offset;

	protected new void Start()
	{
		base.Start();
		if (!body)
			body = GetComponent<Rigidbody2D>();
	}

	public override bool PerformAction()
	{
		if(update && myMind.GetEnemyAim())
		{
			Vector2 directionOfMove = (Vector2)myMind.GetEnemyAim().transform.position + offset - body.position;
			body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1) + addictionalRotation;
		}
		return base.PerformAction();
	}

	public override void EnterAction()
	{
		base.EnterAction();
		if ( myMind.GetEnemyAim())
		{
			offset = Random.insideUnitCircle * Random.Range(aimOffsetMin, aimOffsetMax);
			Vector2 directionOfMove = (Vector2)myMind.GetEnemyAim().transform.position + offset - body.position;
			body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1) + addictionalRotation;
		}
	}


}
