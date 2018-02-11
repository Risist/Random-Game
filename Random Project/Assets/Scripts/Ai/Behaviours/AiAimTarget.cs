using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAimTarget : AiAimBase {

#region Reevaluate
	Timer cdChange = new Timer();
	public float cdChangeMin = 1.0f;
	public float cdChangeMax = 1.0f;
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
		else destination = transform.position;
	}

	public bool RecalculateTarget()
	{
		target = null;
		foreach(var it in myMind.myPerception.memory)
			if(it.fraction && it.fraction.gameObject != myMind.myFraction.gameObject)
				if (myMind.myFraction.GetAttitude(it.fraction.fractionName) == expectedAttitude)
				{
					target = it.fraction;
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
		return destination;
	}
}
