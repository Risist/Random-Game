using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTarget : MonoBehaviour {

	AiPerceiveUnit target = null;

	[System.NonSerialized]
	public AiUnitMind myMind;

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
	Timer timerRecalculate = new Timer();

	public float distanceMin = 0.0f;
	public float distanceMax = float.MaxValue;

	

	private void Start()
	{
		myMind = GetComponentInParent<AiUnitMind>();
	}

	public AiPerceiveUnit GetTarget()
	{
		if (timerRecalculate.isReadyRestart())
		{
			timerRecalculate.cd = Random.Range(reevaluateTimeMin, reevaluateTimeMin);

			target = null;

			/// TODO how to efficiently iterate backwards in c#? Check it
			foreach (var it in myMind.myPerception.memory)
				if (it.unit.fraction && it.unit.fraction.gameObject != myMind.myFraction.gameObject)
					if (CheckRequirements(it))
					{
						target = it.unit;
						break;
					}
		}

		return target;
	}

	bool CheckRequirements(AiPerception.MemoryItem it)
	{
		return myMind.myFraction.GetAttitude(it.unit.fraction.fractionName) == attitude && 
			it.lastDistance >= distanceMin && it.lastDistance <= distanceMax &&
			(fractionName == "" || it.unit.fraction.name == fractionName)
			;
	}

}
