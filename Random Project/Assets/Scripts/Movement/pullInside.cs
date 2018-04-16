using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullInside : MonoBehaviour {

	public float force;
	public float forceIncrease;
	public float forceMax = float.MaxValue;
	public string ignoreTag = "noTag";
	public bool returnOnTrigger = true;
	public bool inverseRotation = false;

	Transform _transform;
	private void Start()
	{
		_transform = transform;
	}


	private void Update()
	{
		force += forceIncrease * Time.deltaTime;
		force = Mathf.Clamp(force, -forceMax, forceMax);
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (returnOnTrigger && collision.isTrigger)
			return;

		var rb = collision.GetComponent<Rigidbody2D>();
		if (rb && rb.tag != ignoreTag)
		{
			rb.AddForce(((Vector2)_transform.position - rb.position).normalized * force);
			if (inverseRotation && collision.isTrigger)
				rb.rotation += 180.0f;
		}
	}
}
