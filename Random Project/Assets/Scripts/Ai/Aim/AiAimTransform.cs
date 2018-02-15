using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAimTransform : AiAimBase {

	public float offsetMin;
	public float offsetMax;


	public Transform aimTransform;

	
	public override Vector2 GetAimPoint()
	{
		if (aimTransform)
			return (Vector2)aimTransform.position + Random.insideUnitCircle * Random.Range(offsetMin, offsetMax);
		else return (Vector2)transform.position + Random.insideUnitCircle * Random.Range(offsetMin, offsetMax);
	}
}
