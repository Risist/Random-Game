using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAllowLocationValid : AiBehaviourBase {

	public AiLocationBase target;
    public bool negation = false;

	public override bool CanEnter()
	{
        if(negation)
            return target && !target.IsValid();
        else
           return target && target.IsValid();
	}
}
