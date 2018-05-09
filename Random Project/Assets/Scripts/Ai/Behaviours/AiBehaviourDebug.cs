using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourDebug : AiBehaviourBase {

	public bool enter = true;
    public bool perform;
    public bool exit;
    public AiLocationBase location;
    int n = 0;
	int nEnter = 0;

	public override void EnterAction()
	{
        if (enter)
            Debug.Log("Enter " + ++nEnter);
		base.EnterAction();
	}
	public override bool PerformAction()
	{
		if(perform)
			Debug.Log("Perform " + ++n );
        if (location && location.IsValid() )
            Debug.Log(location + ": " + location.GetTargetObject() );
		return base.PerformAction();
	}
	public override void ExitAction()
	{
        if(exit)
		    Debug.Log("Exit");
		base.ExitAction();
	}
}
