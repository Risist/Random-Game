using UnityEngine;
using System.Collections;

public class HealOnTriggerSimple : MonoBehaviour {

	public SimpleDamage damageEnter;
	public SimpleDamage damageStay;
	public SimpleDamage damageExit;
	public string ignoreTag = "noTag";

	public bool removeOnEnter = false;
	public bool removeOnExit = false;
	public GameObject objToRemove;
	public AiFraction myFraction;

	private void Start()
	{
		if (!objToRemove)
			objToRemove = gameObject;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageEnter, gameObject);
			if (removeOnEnter)
				Destroy(objToRemove);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if (healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageStay, gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageExit, gameObject);
			if (removeOnExit)
				Destroy(objToRemove);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageEnter, gameObject);
			if (removeOnEnter)
				Destroy(objToRemove);
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageStay, gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) != AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageExit, gameObject);
			if (removeOnExit)
				Destroy(objToRemove);
		}
	}
}
