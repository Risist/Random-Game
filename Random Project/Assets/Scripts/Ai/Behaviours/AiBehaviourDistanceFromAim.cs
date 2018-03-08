using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourDistanceFromAim : AiBehaviourBase{

	public AiLocationBase aim;
	public float distanceMin = 0.0f;
	public float distanceMax = 1000000.0f;
	public bool inside = true;


	public override bool CanEnter()
	{
		float distanceSq = ((Vector2)transform.position - aim.GetLocation()).sqrMagnitude;
		bool b = distanceSq < distanceMax * distanceMax && distanceSq > distanceMin * distanceMin;
		return inside ? b : !b;
	}
}
