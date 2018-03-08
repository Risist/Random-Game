using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAllowOrder : AiBehaviourBase {

	public string orderName;
	public AiLocationHolder holder;

	public override bool CanEnter()
	{
		if (myMind.myArmy && base.CanEnter())
		{
			var v = myMind.myArmy.HasOrder_Struct(orderName, transform.position);
			if (v != null)
			{
				holder.location = v.position;
			}

			return  v != null;
		}
		return false;
	}
}
