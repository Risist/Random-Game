using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationTransform : AiLocationBase{

	public Transform aim;

	new public void Start()
	{
		base.Start();
		if (!aim)
			aim = transform;
	}

	public override Vector2 GetLocation()
	{
		return base.GetLocation() + (Vector2)aim.position;
	}
    public override GameObject GetTargetObject()
    {
        return aim.gameObject;
    }
    public override bool IsValid()
	{
		return aim && base.IsValid();
	}
}
