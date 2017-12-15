using UnityEngine;
using System.Collections;

public class DamageOnTriggerSimple : MonoBehaviour {

	public SimpleDamage damageEnter;
	public SimpleDamage damageStay;
	public SimpleDamage damageExit;

	void OnTriggerEnter2D(Collider2D other)
	{
		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if (other.isTrigger == false && healthController != null)
		{
			healthController.DealDamage(damageEnter, gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if (other.isTrigger == false && healthController != null)
		{
			healthController.DealDamage(damageStay, gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		HealthController healthController = other.gameObject.GetComponent<HealthController>();
		if (other.isTrigger == false && healthController != null)
		{
			healthController.DealDamage(damageExit, gameObject);
		}
	}
}
