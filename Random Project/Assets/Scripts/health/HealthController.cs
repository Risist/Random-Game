using UnityEngine;
using System.Collections;

/*
 * Two kinds of events:
 *      death event (method "OnReceiveDamage" with HealthController.DamageData argument) - called once the character is considered as dead
 *      damage event (method "OnDeath" with HealthController.DamageData argument) - called everytime character takes damage, unless those damage are fatal
 *      
 * 
 * 
 */

public class HealthController : MonoBehaviour
{

    public float actual = 100;
    public float max = 100;
	// health regeneration in units/s 
	public float regeneration = 0;
	// perform removing of owner at OnDeath event?
	public bool removeAfterDeath = true;
	// object to remove after death
	// in case you should remove at death something else than owner of the script
	// if not set up the value is assigned to an owner of the script 
	public GameObject objectToRemove;
    public bool IsAlive()
    {
        return actual > 0;
    }

	private void Start()
	{
		if (removeAfterDeath && !objectToRemove)
			objectToRemove = gameObject;
	}
	private void Update()
	{
		DealDamage(regeneration * Time.deltaTime, gameObject);
	}

	/// struct for broadcasting messages
	public struct DamageData
    {
        public DamageData(IDamageType _d, GameObject _o) { damage = _d; causer = _o; }
        public IDamageType damage;
        public GameObject causer;
    }

    public void DealDamage(IDamageType damage, GameObject causer = null)
    {
        damage.ChangeHealth(this, causer);

        var data = new DamageData(damage, causer);

        if (IsAlive())
        {
            BroadcastMessage("OnReceiveDamage", data );
        }
        else
        {
			BroadcastMessage("OnDeath", data);
        }

		actual = Mathf.Clamp(actual, 0, max);
    }
    public void DealDamage(float damage, GameObject causer = null)
    {
        DealDamage(new SimpleDamage(damage), causer);
    }
	void OnReceiveDamage(DamageData data)
	{

	}
	void OnDeath(DamageData data)
	{
		if(objectToRemove)
			Destroy(objectToRemove);
	}

}