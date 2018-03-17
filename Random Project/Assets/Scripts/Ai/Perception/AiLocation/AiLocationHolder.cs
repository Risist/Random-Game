using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationHolder : AiLocationBase
{
	public Vector2 location;

	public override Vector2 GetLocation()
	{
		return base.GetLocation() + location;
	}

}
