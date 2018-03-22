﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAllowRay : AiBehaviourBase {

	public AiLocationBase aim;
	public AiFraction.Attitude attitude = AiFraction.Attitude.none;
	public string fractionName = "noFraction";

	Transform _transform;
	private new void Start()
	{
		base.Start();
		_transform = transform;
	}

	static RaycastHit2D[] hits = new RaycastHit2D[20];
	public override bool CanEnter()
	{
		Vector2 direction = (Vector2)transform.position - aim.GetLocation();
		int n = Physics2D.RaycastNonAlloc(transform.position, direction.normalized, hits, direction.magnitude);
		for(int i = 0; i < n; ++i)
		{
			var it = hits[i];
			var unit = it.collider.GetComponent<AiPerceiveUnit>();
			if (unit && unit.fraction &&
					(unit.fraction.fractionName == fractionName ||
					unit.fraction.GetAttitude(myMind.myFraction.fractionName) == attitude)
				)
			{
				return false;
			}
		}
		return true;
	}
}