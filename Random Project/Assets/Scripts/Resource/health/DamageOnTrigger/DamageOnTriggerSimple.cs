using UnityEngine;
using System.Collections;

public class DamageOnTriggerSimple : MonoBehaviour {

	public SimpleDamage damageEnter;
	public SimpleDamage damageStay;
	public SimpleDamage damageExit;
	public string ignoreTag = "noTag";

	public bool removeOnEnter = false;
	public bool removeOnExit = false;
    public bool removeOnCollision = true;
    public bool removeOnTrigger = true;
    public GameObject objToRemove;
	public AiFraction myFraction;
	public GameObject instigator;

	private void Start()
	{
		if (!objToRemove)
			objToRemove = gameObject;
		if (!instigator)
			instigator = gameObject;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageEnter, instigator);
            if (removeOnEnter)
            {
                if( (other.isTrigger && removeOnTrigger) ||
                    (!other.isTrigger && removeOnCollision))
                    Destroy(objToRemove);
            }
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if (healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageStay, instigator);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageExit, instigator);
			if (removeOnExit)
            {
                if ((other.isTrigger && removeOnTrigger) ||
                    (!other.isTrigger && removeOnCollision))
                    Destroy(objToRemove);
            }
        }
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageEnter, gameObject);
			if (removeOnEnter)
            {
                if ((other.collider.isTrigger && removeOnTrigger) ||
                    (!other.collider.isTrigger && removeOnCollision))
                    Destroy(objToRemove);
            }
        }
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (myFraction)
		{
			var otherFraction = other.gameObject.GetComponent<AiFraction>();
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
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
			if (otherFraction && myFraction.GetAttitude(otherFraction.fractionName) == AiFraction.Attitude.friendly)
				return;
		}

		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if ( healthController != null && other.gameObject.tag != ignoreTag)
		{
			healthController.DealDamage(damageExit, gameObject);
			if (removeOnExit)
            {
                if ((other.collider.isTrigger && removeOnTrigger) ||
                    (!other.collider.isTrigger && removeOnCollision))
                    Destroy(objToRemove);
            }
        }
	}
}
