using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourWait : AiBehaviourBase
{
	public override bool PerformAction()
	{
		return performanceTimer.isReady();
	}
	public override void EnterAction()
	{
		resetPerformanceTimer();
		base.EnterAction();
	}

#region Performance Timer
	/// to avoid stuck in performing the action here you can set up maximal time spent
	Timer performanceTimer = new Timer();
	public float minPerformanceTime = 1.0f;
	public float maxPerformanceTime = 1.0f;
	public void resetPerformanceTimer()
	{
		performanceTimer.restart(); performanceTimer.cd = Random.Range(minPerformanceTime, maxPerformanceTime);
	}
#endregion Performace Timer
}
