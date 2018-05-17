using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMemory : MonoBehaviour {

    AiPerception perception;

	// Use this for initialization
	void Start () {
        perception = GetComponentInChildren<AiPerception>();
	}
    public void OnReceiveDamage(HealthController.DamageData data)
    {
        if (data.causer == null)
            return;

        var unit = data.causer.GetComponentInParent<AiPerceiveUnit>();
        if (unit)
        {
            perception.insertToMemory(unit, ((Vector2)transform.position - (Vector2)unit.transform.position).magnitude );
        }
    }
}
