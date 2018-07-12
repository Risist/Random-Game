using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAllowRay : AiBehaviourBase {

	public AiLocationBase aim;
	public AiFraction.Attitude attitude = AiFraction.Attitude.none;
	public string fractionName = "noFraction";
    public float raysOffset = 2.0f;
    
	private new void Start()
	{
		base.Start();   
	}

	static RaycastHit2D[] hits = new RaycastHit2D[20];
	public override bool CanEnter()
	{
		Vector2 direction = (Vector2)myMind.transform.position - aim.GetLocation();
        Vector2 prepDir = new Vector2(-direction.y, direction.x).normalized;
        int n = Physics2D.RaycastNonAlloc((Vector2)myMind.transform.position + prepDir* raysOffset, direction.normalized, hits, direction.magnitude);
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
        n = Physics2D.RaycastNonAlloc((Vector2)myMind.transform.position - prepDir * raysOffset, direction.normalized, hits, direction.magnitude);
        for (int i = 0; i < n; ++i)
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
