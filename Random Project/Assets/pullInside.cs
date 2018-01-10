using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullInside : MonoBehaviour {

	public float force;
	public float forceIncrease;

	private void Update()
	{
		force += forceIncrease * Time.deltaTime;
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		var rb = collision.GetComponent<Rigidbody2D>();
		if (rb)
		{
			rb.AddForce(((Vector2)transform.position - rb.position).normalized * force);
		}
	}
}
