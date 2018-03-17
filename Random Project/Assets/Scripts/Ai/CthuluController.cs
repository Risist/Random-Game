using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthuluController : MonoBehaviour {

	Rigidbody2D rb;

	public float torqueMin = -5;
	public float torqueMax = 5;
	[Range(0.0f, 1.0f)]
	public float averageFactor = 0;
	[Range(0.0f, 1.0f)]
	public float followFactor = 0;

	public float followFactorIgnoreDifference = 5.0f;
	public float followScale = 0.1f;

	public Timer timerRescan;

	AiPerception perception;
	AiFraction fraction;

	GameObject aim;

	float averageTorque;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		perception = GetComponent<AiPerception>();
		fraction = GetComponent<AiFraction>();
	}
	
	void Update () {
		if (timerRescan.isReadyRestart())
			foreach (var it in perception.memory)
			{
				if (it.unit && it.unit.gameObject != gameObject && it.unit.fraction 
					&& fraction.GetAttitude(it.unit.fraction.fractionName) == AiFraction.Attitude.enemy)
				{
					aim = it.unit.gameObject;
					break;
				}
			}
	}

	void FixedUpdate()
	{
		float followDir = 0;
		if (aim)
		{
			Vector2 toFollow = transform.position - aim.transform.position;
			followDir = Quaternion.FromToRotation(Vector2.down, toFollow).eulerAngles.z;

			if (Mathf.Abs(followDir) < followFactorIgnoreDifference)
				return;
		}
		followDir -= transform.rotation.eulerAngles.z;

		averageTorque = averageTorque * averageFactor + Random.Range(torqueMin, torqueMax) * Time.fixedDeltaTime * (1 - averageFactor);
		rb.AddTorque(followDir * followFactor * followScale + averageTorque * (1 - followFactor));
	}

}
