using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonOnCollision : MonoBehaviour {

	public float enterForce;
	public float stayForce;
	public float exitForce;

	public string ignoreTag = "noTag";

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var hp = collision.GetComponent<HealthController>();
		if(hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= enterForce;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		var hp = collision.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= stayForce*Time.deltaTime;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		var hp = collision.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= exitForce;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var hp = collision.gameObject.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= enterForce;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		var hp = collision.gameObject.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= stayForce * Time.deltaTime;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		var hp = collision.gameObject.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			hp.regeneration -= exitForce;
		}
	}
}
