using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTorque
	: MonoBehaviour {

	public Rigidbody2D rb;
	public float torqueMin=-5;
	public float torqueMax = 5;
	[Range(0.0f,1.0f )]
	public float averageFactor = 0;
	[Range(0.0f, 1.0f)]
	public float followFactor = 0;

	public float followFactorIgnoreDifference = 5.0f;
	public string objectToFollowTag;
	public float followScale = 0.1f;
	GameObject objToFollow;

	float averageTorque;

	// Use this for initialization
	void Start () {
		if (!rb)
			rb = GetComponent<Rigidbody2D>();
		objToFollow = GameObject.FindGameObjectWithTag(objectToFollowTag);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float followDir = 0;
		if(objToFollow)
		{
			Vector2 toFollow = transform.position - objToFollow.transform.position;
			followDir = Quaternion.FromToRotation(Vector2.down, toFollow).eulerAngles.z;

			if (Mathf.Abs(followDir) < followFactorIgnoreDifference)
				return;
		}
		followDir -= transform.rotation.eulerAngles.z;

		averageTorque = averageTorque * averageFactor + Random.Range(torqueMin, torqueMax) * Time.fixedDeltaTime * (1 - averageFactor);
		rb.AddTorque( followDir * followFactor * followScale + averageTorque * (1 - followFactor) );	
	}
}
