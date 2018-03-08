using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAllowLocationValid : AiBehaviourBase {

	public AiLocationBase target;

	public override bool CanEnter()
	{
		return target && target.IsValid();
	}
}
