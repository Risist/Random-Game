using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationSteeringOne : AiLocationBase {

	public AiLocationBase aim;
	public float minDistance;
	public float maxDistance;

	[Range(0.0f, 1.0f)]
	public float correctionScale = 0.25f;

	Transform _transform;

	// Use this for initialization
	new void Start () {
		base.Start();
		_transform = transform;
	}

	public override Vector2 GetLocation()
	{
		Vector2 toTarget = (Vector2)_transform.position - aim.GetLocation();
		Vector2 basePos = base.GetLocation();
		Vector2 location = (Vector2)_transform.position;
		float sqMag = toTarget.sqrMagnitude;
		if (sqMag < minDistance * minDistance)
			location = (Vector2)_transform.position + toTarget;
		else if (sqMag > maxDistance * maxDistance)
			location = aim.GetLocation();
		return basePos*(1.0f - correctionScale) + location*correctionScale;
	}
}
