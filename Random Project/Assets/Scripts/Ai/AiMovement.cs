using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

	public float maximalMovementSpeed = float.PositiveInfinity;
	public float maximalRotationSpeed = float.PositiveInfinity;


	[Range(0.0f, 1.0f)]
	public float positionDamping = 0.0f;
	[Range(0.0f, 1.0f)]
	public float rotationDamping = 0.0f;

	public float addictionalRotation = 0.0f;

	[System.NonSerialized]
	public NewtonianResource rotation = new NewtonianResource();

	Vector2 influenceRotation;
	Vector2 influencePosition;
    public Vector2 GetInfluencePosition()
    {
        return influencePosition;
    }
    public Vector2 GetInfluenceRotation()
    {
        return influenceRotation;
    }


    Rigidbody2D body;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
		rotation.value = body.rotation;
		//rotation.inverseMass = 1/body.mass;
		rotation.velocityDamping = 1/body.angularDrag;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{

		if (influencePosition.sqrMagnitude > maximalMovementSpeed * maximalMovementSpeed)
			body.AddForce(influencePosition.normalized * maximalMovementSpeed * Time.fixedDeltaTime);
		else body.AddForce(influencePosition * Time.fixedDeltaTime);

		float difference = Vector2.Dot(-transform.right, influenceRotation);
        Debug.Log(difference);

		if (influenceRotation.sqrMagnitude < maximalRotationSpeed * maximalRotationSpeed){
			if (Vector2.Dot(transform.up, influenceRotation) < 0)
				difference = Mathf.Sign(difference) * influenceRotation.magnitude;
		}
		else
			difference = Mathf.Sign(difference) * maximalRotationSpeed;

		rotation.AddForce(difference * Time.fixedDeltaTime);

		rotation.FixedUpdate();

		influencePosition *= positionDamping;
		influenceRotation *= rotationDamping;

		body.rotation = rotation.value + addictionalRotation;
	}



#region Apply

	public void SetRotation( float s)
	{
		rotation.value = s;
	}
	public void SetRotationPoint(Vector2 point)
	{
		point = (point - (Vector2)transform.position);
		rotation.value = Vector2.Angle(Vector2.up, point) * (point.x > 0 ? -1 : 1);
	}

	public void ApplyInfluence(Vector2 inf)
	{
		influencePosition += inf;
		influenceRotation += inf;
	}
	public void ApplyInfluencePosition(Vector2 inf)
	{
		influencePosition += inf;
	}
	public void ApplyInfluenceRotation(Vector2 inf)
	{
		influenceRotation += inf;
	}

	public void ApplyInfluencePoint(Vector2 point, 
		float movementSpeed = 1000.0f, float rotationSpeed = 100.0f, 
		float stopDistance = 0.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);

		float sqMag = inf.sqrMagnitude;
		inf.Normalize();
		if (sqMag > stopDistance * stopDistance)
			influencePosition += inf * movementSpeed;

		influenceRotation += inf * rotationSpeed;
	}
	public void ApplyInfluencePointPosition(Vector2 point, float movementSpeed = 1000.0f, float stopDistance = 0.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);
		if (inf.sqrMagnitude < stopDistance * stopDistance)
			return;
		inf.Normalize();
		influencePosition += inf * movementSpeed;
	}
	public void ApplyInfluencePointRotation(Vector2 point, float rotationSpeed = 100.0f)
	{
		Vector2 inf = (point - (Vector2)transform.position);
		inf.Normalize();
		influenceRotation += inf * rotationSpeed;
	}
#endregion Apply

}
