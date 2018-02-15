using UnityEngine;
using System.Collections;

[System.Serializable]
public class NewtonianResource
{
	public float value;
	[Range(0.0f, 1.0f)]
	public float velocityDamping = 0.9f;
	[Range(0.0f, 1.0f)]
	public float forceDamping = 0.0f;
	public float inverseMass = 1.0f;

	float velocity;
	float force;

	public float GetVelocity() { return velocity; }
	public float GetForce() { return force; }

	public void FixedUpdate()
	{
		velocity += force * inverseMass;
		value += velocity;

		velocity *= velocityDamping;
		force *= forceDamping;
	}
	public void AddForce(float f) { force += f; }


}
