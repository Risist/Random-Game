using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  The spell is a big fail ...
/// </summary>
public class SpearController : MonoBehaviour {
	
	[Range(0.0f,1.0f)]
	public float jointLooseLenght;
	public Timer removeAfterConnectionTimmer;
	public Vector2 connectionPointPlayer;
	public Vector2 connectionPointAim;

	SpringJoint2D jointPlayer;
	SpringJoint2D jointAim;
	bool connected = false;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(connected)
		{
			jointPlayer.distance = jointPlayer.distance * jointLooseLenght;
			jointAim.distance = jointAim.distance * jointLooseLenght;

			if (removeAfterConnectionTimmer.isReady())
				Destroy(gameObject);

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (connected)
			return;

		//var hp = collision.gameObject.GetComponent<HealthController>();
		var rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
		if (!collision.isTrigger)
		{
			connected = true;

			jointPlayer = gameObject.AddComponent<SpringJoint2D>();
			jointPlayer.connectedBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
			jointPlayer.distance = (transform.position - jointPlayer.connectedBody.transform.position).magnitude;
			jointPlayer.anchor = connectionPointPlayer;

			jointAim = gameObject.AddComponent<SpringJoint2D>();
			if (rigidbody)
				jointAim.connectedBody = rigidbody;
			else
				jointAim.connectedAnchor = collision.gameObject.transform.position;
			jointAim.distance = (transform.position - collision.gameObject.transform.position).magnitude;
			jointAim.anchor = connectionPointAim;

			var rb = GetComponent<Rigidbody2D>();
			rb.velocity = Vector2.zero;
			rb.drag = 900000;

			GetComponent<Motor>().movementSpeed = 0;

			removeAfterConnectionTimmer.restart();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (connected)
			return;

		//var hp = collision.gameObject.GetComponent<HealthController>();
		var rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
		if (!collision.collider.isTrigger)
		{
			connected = true;

			jointPlayer = gameObject.AddComponent<SpringJoint2D>();
			jointPlayer.connectedBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
			jointPlayer.distance = (transform.position - jointPlayer.connectedBody.transform.position).magnitude;
			jointPlayer.anchor = connectionPointPlayer;

			jointAim = gameObject.AddComponent<SpringJoint2D>();
			if (rigidbody)
				jointAim.connectedBody = rigidbody;
			else
				jointAim.connectedAnchor = collision.gameObject.transform.position;
			jointAim.distance = (transform.position - collision.gameObject.transform.position).magnitude;
			jointAim.anchor = connectionPointAim;

			var rb = GetComponent<Rigidbody2D>();
			rb.velocity = Vector2.zero;
			rb.drag = 900000;

			GetComponent<Motor>().movementSpeed = 0;

			removeAfterConnectionTimmer.restart();
		}
	}
}
