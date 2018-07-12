using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourRotateTo : AiBehaviourBase {

	public AiLocationBase aim;
	public bool update = true;
	public float rotationSpeed;
    public bool monopoliseRotation = false;
	AiMovement movement;

	protected new void Start()
	{
		base.Start();
		movement = GetComponentInParent<AiMovement>();
	}
	public override bool PerformAction()
	{
		if (update)
		{
            if (monopoliseRotation)
                movement.ApplyInfluenceRotation(-movement.GetInfluenceRotation());
			movement.ApplyInfluencePointRotation(aim.GetLocation(), rotationSpeed);
		}
		return true;
	}

	public override void EnterAction()
	{
		base.EnterAction();
		if (!update)
        {
            if (monopoliseRotation)
                movement.ApplyInfluenceRotation(-movement.GetInfluenceRotation());
            movement.SetRotationPoint(aim.GetLocation());
		}
	}

}
