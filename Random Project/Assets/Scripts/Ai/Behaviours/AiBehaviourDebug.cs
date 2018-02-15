using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourDebug : AiBehaviourBase {

	public bool perform;
	int n = 0;
	int nEnter = 0;

	public override void EnterAction()
	{
		Debug.Log("Enter " + ++nEnter);
		base.EnterAction();
	}
	public override bool PerformAction()
	{
		if(perform)
			Debug.Log("Perform " + ++n );
		return base.PerformAction();
	}
	public override void ExitAction()
	{
		Debug.Log("Exit");
		base.ExitAction();
	}
}
