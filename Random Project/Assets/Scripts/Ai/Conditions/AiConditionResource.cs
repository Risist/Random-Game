using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiConditionResource : AiConditionBase{

	public ResourceController resource;
	public float resourcePercentScale;

	public override float GetUtility()
	{
		return base.GetUtility() + resource.actual/ resource.max * resourcePercentScale;
	}
}
