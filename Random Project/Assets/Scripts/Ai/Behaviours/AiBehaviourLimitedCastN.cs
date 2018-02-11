using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourLimitedCastN : AiBehaviourBase {

	public int castLeft = 1;
	public override bool CanEnter()
	{
		if(castLeft > 0)
		{
			--castLeft;
			return true;
		}
		return false;
	}
}
