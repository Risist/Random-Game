using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourSteeringOne : AiBehaviourBase {

	public Transform target;
	public float minDistance;
	public float maxDistance;

	public float force;

	Transform _transform;
	AiMovement movement;

	new private void Start()
	{
		base.Start();
		movement = GetComponentInParent<AiMovement>();
		_transform = transform;
	}

	public override bool PerformAction()
	{
		Vector2 toTarget = target.position - _transform.position;
		float sqMag = toTarget.sqrMagnitude;
		//if (sqMag < minDistance * minDistance)
			//movement.applyInfluencePointPosition((Vector2)_transform.position + toTarget, force);
		//else if (sqMag > maxDistance * maxDistance)
			movement.ApplyInfluencePosition(force* toTarget);
		Debug.Log("fsfsdfs");
		return true;
	}
}
