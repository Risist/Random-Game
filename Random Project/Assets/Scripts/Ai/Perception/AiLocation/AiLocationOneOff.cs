using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationOneOff : AiLocationBase {

	public AiLocationBase[] targetList;

	public override AiPerceiveUnit GetTarget()
	{
		foreach (var it in targetList)
			if(it.IsValid())
		{
			return it.GetTarget();
		}
		return null;
	}
	public override GameObject GetTargetObject()
	{
		foreach (var it in targetList)
			if (it.IsValid())
			{
				return it.GetTargetObject();
			}
		return null;
	}
	public override Vector2 GetLocation()
	{
		foreach (var it in targetList)
			if (it.IsValid())
			{
				return it.GetLocation();
			}
		return Vector2.zero;
	}

	public override bool IsValid()
	{
		foreach (var it in targetList)
			if (it.IsValid())
			{
				return true;
			}
		return false;
	}
	
}
