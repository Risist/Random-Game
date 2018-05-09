using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiLocationTarget : AiLocationBase {

	AiPerceiveUnit target = null;

	public AiFraction.Attitude attitude = AiFraction.Attitude.none;
	public string fractionName = "";

	/// TODO
	public enum Order
	{
		// start search from farest perceived object
		far,
		// start search from closest perceived object
		close,
	}
	//public Order order = Order.close;

	public float reevaluateTimeMin = 0.0f;
	public float reevaluateTimeMax = 0.0f;
	Timer timerRecalculate = new Timer(0);

	public float distanceMin = 0.0f;
	public float distanceMax = float.MaxValue;


	public override AiPerceiveUnit GetTarget()
	{
		if (timerRecalculate.isReadyRestart())
		{
			timerRecalculate.cd = Random.Range(reevaluateTimeMin, reevaluateTimeMin);

			target = null;

            /// TODO how to efficiently iterate backwards in c#? Check it
            foreach (var it in mind.myPerception.memory)
                if (it.unit.fraction && it.unit.fraction.gameObject != mind.myFraction.gameObject)
                {
                    if (CheckRequirements(it))
                    {
                        target = it.unit;
                        break;
                    }
                }
		}

		return target;
	}

	bool CheckRequirements(AiPerception.MemoryItem it)
	{
		return (attitude == AiFraction.Attitude.none || mind.myFraction.GetAttitude(it.unit.fraction.fractionName) == attitude ) && 
			it.lastDistance >= distanceMin && it.lastDistance <= distanceMax &&
			(fractionName == "" || it.unit.fraction.fractionName.Equals(fractionName) )
			;
	}

	public override bool IsValid()
	{
        return GetTarget() && base.IsValid();
	}
	public override Vector2 GetLocation()
	{
		GetTarget();
		return base.GetLocation() + (target != null ? (Vector2)target.transform.position : Vector2.zero);
	}
}
