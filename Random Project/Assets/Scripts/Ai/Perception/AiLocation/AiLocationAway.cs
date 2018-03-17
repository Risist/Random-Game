using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationAway : AiLocationBase {
	
	public float awayDistance;
	public Transform _transform;

	new private void Start()
	{
		base.Start();
	}

	public override Vector2 GetLocation()
	{
		Vector2 flee = base.GetLocation();

		Vector2 v = ((Vector2)_transform.position - flee);
		return flee + v.normalized * awayDistance;
	}
}
