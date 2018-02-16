using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAimAttitude : AiAimBase {

#region Reevaluate
	Timer cdChange = new Timer();
	public float cdChangeMin = 0.0f;
	public float cdChangeMax = 0.0f;
	public void ResetCdChange()
	{
		cdChange.restart();
		cdChange.cd = Random.Range(cdChangeMin, cdChangeMax);
	}
#endregion Reevaluate

	public AiFraction.Attitude expectedAttitude;
	public float offsetMin;
	public float offsetMax;


	public void RecalculateDestination()
	{
		if (target)
			destination = (Vector2)target.transform.position + Random.insideUnitCircle * Random.Range(offsetMin, offsetMax);
		else
		{
			destination = transform.position;
		}
	}

	public bool RecalculateTarget()
	{
		target = null;
		foreach(var it in myMind.myPerception.memory)
			if(it.unit.fraction && it.unit.fraction.gameObject != myMind.myFraction.gameObject)
				if (myMind.myFraction.GetAttitude(it.unit.fraction.fractionName) == expectedAttitude)
				{
					target = it.unit.fraction;
					//Debug.Log("found " + myMind.gameObject + " against " + it.unit.gameObject);
					return true;
				}
		return false;
	}

	AiFraction target;
	Vector2 destination;

	public override void EnterAction()
	{
		base.EnterAction();
		ResetCdChange();
		RecalculateDestination();
	}
	public override bool CanEnter()
	{
		return RecalculateTarget();
	}

	public override Vector2 GetAimPoint()
	{
		if (!target)
			RecalculateTarget();

		if (cdChange.isReady())
		{
			ResetCdChange();
			RecalculateDestination();
		}


		//Debug.Log("destination = " + destination + " target " + target);
		return destination;
	}
}
