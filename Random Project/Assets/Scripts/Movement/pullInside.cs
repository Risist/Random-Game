using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullInside : MonoBehaviour {

	public float force;
	public float forceIncrease;
	public float forceMax = float.MaxValue;
	public string ignoreTag = "noTag";

	private void Update()
	{
		force += forceIncrease * Time.deltaTime;
		force = Mathf.Clamp(force, -forceMax, forceMax);
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		var rb = collision.GetComponent<Rigidbody2D>();
		if (rb && rb.tag != ignoreTag)
		{
			rb.AddForce(((Vector2)transform.position - rb.position).normalized * force);
		}
	}
}
