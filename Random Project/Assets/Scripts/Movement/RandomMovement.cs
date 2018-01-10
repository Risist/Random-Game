using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

	public float movementSpeed;
	public float minimalDistance;
	public float minRadius;
	public float maxRadius;
	public float cdMin;
	public float cdMax;

	public float addictionalRotation;

	Timer cd = new Timer();

	Vector2 aim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		cd.cd = Random.Range(cdMin, cdMax);
		cd.restart();

		rb = GetComponent<Rigidbody2D>();

		aim = Random.insideUnitCircle * Random.Range(minRadius, maxRadius) + (Vector2)transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(cd.isReadyRestart())
		{
			aim = Random.insideUnitCircle * Random.Range(minRadius, maxRadius) + (Vector2)transform.position;
		}

		if ((aim - rb.position).sqrMagnitude > minimalDistance * minimalDistance)
		{
			Vector2 directionOfMove = (aim - (Vector2)transform.position).normalized;

			rb.AddForce(directionOfMove * movementSpeed * Time.fixedDeltaTime);
			rb.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1) + addictionalRotation;
		}
	}
}
