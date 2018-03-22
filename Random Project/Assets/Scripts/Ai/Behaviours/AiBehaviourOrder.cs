using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourOrder : AiBehaviourBase {

	public string orderName;
	public float orderRadius;
	public float orderTime;

	public override void EnterAction()
	{
		base.EnterAction();
		myMind.myArmy.AddOrder(orderName, transform.position, orderRadius, orderTime);
	}

	public override bool CanEnter()
	{
		return base.CanEnter() && myMind.myArmy;
	}
}
