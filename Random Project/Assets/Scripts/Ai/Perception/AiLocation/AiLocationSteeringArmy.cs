using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationSteeringArmy : AiLocationBase {
	
	public float minDistance = 0.0f;
	public float maxDistance = float.PositiveInfinity;
	public float correctionDistance = 1.0f;

	[Range(0.0f, 1.0f)]
	public float correctionScale = 0.25f;

	Transform _transform;
	AiUnitMind myMind;
	// Use this for initialization
	new void Start()
	{
		base.Start();
		_transform = transform;
		myMind = GetComponentInParent<AiUnitMind>();
	}

	public override Vector2 GetLocation()
	{
		Vector2 correction = myMind.myArmy.GetCorrectionLocationAvoidance
				(_transform.position, minDistance, myMind, correctionDistance);
		if (correction == (Vector2)_transform.position)
			return base.GetLocation();
		else
			return base.GetLocation() * (1.0f - correctionScale) + 
					correction* correctionScale;
	}
}
