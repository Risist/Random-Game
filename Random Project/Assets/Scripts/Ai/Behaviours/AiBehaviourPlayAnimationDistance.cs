using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourPlayAnimationDistance : AiBehaviourPlayAnimation {

    public AiLocationBase location;
    public float minDistance;
    public float maxDistance = float.PositiveInfinity;

    protected new void Start()
    {
        base.Start();
    }

    public override bool PerformAction()
    {
        if (b)
        {
            float distSq = (location.GetLocation() - (Vector2)transform.position).sqrMagnitude;
            if (distSq > minDistance * minDistance && distSq < maxDistance * maxDistance)
            {
                PlayAnimationTrigger();
                b = false;
            }
        }
        return true;
    }
}
