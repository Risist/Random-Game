using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourCd : AiBehaviourBase{

	private new void Start()
	{
		base.Start();
		resetPerformanceTimer();
	}

	public override bool CanEnter()
	{
		if(cdTimer.isReady())
		{
			resetPerformanceTimer();
			return true;
		}
		return false;
	}

	#region Performance Timer
	/// to avoid stuck in performing the action here you can set up maximal time spent
	Timer cdTimer = new Timer();
	public float minCdTime = 1.0f;
	public float maxCdTime = 1.0f;
	public void resetPerformanceTimer()
	{
		cdTimer.restart(); cdTimer.cd = Random.Range(minCdTime, maxCdTime);
	}
#endregion Performace Timer
}
