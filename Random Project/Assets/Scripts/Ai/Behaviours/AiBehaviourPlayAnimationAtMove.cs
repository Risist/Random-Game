using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourPlayAnimationAtMove : AiBehaviourPlayAnimation{

    public float minDistance;
    public float maxDistance = float.PositiveInfinity;

    AiMovement movement;

    protected new void Start()
    {
        base.Start();
        movement = GetComponentInParent<AiMovement>();
    }

    public override bool PerformAction()
    {
        if (b 
            && movement.GetInfluencePosition().sqrMagnitude > minDistance * minDistance
            && movement.GetInfluencePosition().sqrMagnitude < maxDistance * maxDistance)
        {
            PlayAnimationTrigger();
            b = false;
        }
        return true;
    }
}
