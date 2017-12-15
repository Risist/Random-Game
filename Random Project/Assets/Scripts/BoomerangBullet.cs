using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour {


	public new Rigidbody2D rigidbody;
	public float movementSpeed;
	public float rotationSpeed;


	// Use this for initialization
	void Start()
	{
		if (rigidbody == null)
			rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		rigidbody.AddForce(
			new Vector2(transform.up.x, transform.up.y)
			* movementSpeed * Time.fixedDeltaTime
		);
		rigidbody.AddTorque(rotationSpeed * Time.fixedDeltaTime);
	}
}
