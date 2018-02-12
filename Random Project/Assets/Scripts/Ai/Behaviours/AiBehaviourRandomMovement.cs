using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourRandomMovement : AiBehaviourMotor
{

	Timer cd = new Timer();
	public float minCd = 1.0f;
	public float maxCd = 1.0f;
	protected void RestartCd() { cd.restart(); cd.cd = Random.Range(minCd, maxCd); }

	public Transform center;
	public float radiusMin = 3.0f;
	public float radiusMax = 3.0f;

	public float stopDistance = 1.0f;

	Vector2 destination = Vector2.zero;
	void RandDestination()
	{
		destination = (Vector2)center.position + Random.insideUnitCircle * Random.Range(radiusMin, radiusMax);
	}

	// Use this for initialization
	new void Start()
	{
		base.Start();
		if (!center)
			center = transform;

	}

	public override void EnterAction()
	{
		RestartCd();
		RandDestination();
		base.EnterAction();
	}
	public override bool PerformAction()
	{
		if (cd.isReady())
		{
			RestartCd();
			RandDestination();
		}

		Vector2 directionOfMove = destination - body.position;
		if (directionOfMove.sqrMagnitude > stopDistance * stopDistance)
		{
			body.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1);
			bShouldMove = true;
		}

		return true;
	}
}