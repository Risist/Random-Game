using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour {


	public new Rigidbody2D rigidbody;
	public Vector2 movementSpeed;
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
			* movementSpeed.y * Time.fixedDeltaTime
		);
		rigidbody.AddForce(
			new Vector2(transform.right.x, transform.right.y)
			* movementSpeed.x * Time.fixedDeltaTime
		);
		rigidbody.AddTorque(rotationSpeed * Time.fixedDeltaTime);
	}
}
