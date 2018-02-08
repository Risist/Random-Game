using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmyBehaviourBase : MonoBehaviour
{
	public ArmyUnitMind myMind;
	protected void Start()
	{
		if (!myMind)
			myMind = GetComponent<ArmyUnitMind>();
	}

	#region virtual
	/// to avoid stuck in performing the action here you can set up maximal time spent
	public Timer maxPerformanceTime;

	/// Called every frame after selecting the behaviour to be executed.
	/// <returns> has the action ended performance? </returns>
	public virtual bool PerformAction() { return maxPerformanceTime.isReady(); }
	/// Called every physics update after selecting the behaviour to be executed.
	public virtual void PerformActionFixed() { }

	public float baseUtility = 1.0f;
	public virtual float GetUtility(string orderCode) { return baseUtility; }

	/// Called upon selecting the behaviour. All state initialisation code goes here
	public virtual void ExitAction()
	{
	}
	/// Called upon selecting the behaviour. All state initialisation code goes here
	public virtual void EnterAction()
	{
		maxPerformanceTime.restart();
	}
	#endregion virtual
}
