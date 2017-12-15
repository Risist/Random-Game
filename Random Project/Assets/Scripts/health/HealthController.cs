using UnityEngine;
using System.Collections;

/*
 * Two kinds of events:
 *      death event (method "OnTakeDamage" with HealthController.DamageData argument) - called once the character is considered as dead
 *      damage event (method "OnDeath" with HealthController.DamageData argument) - called everytime character takes damage, unless those damage are fatal
 *      
 * 
 * 
 */

public class HealthController : MonoBehaviour
{

    public float actual = 100;
    public float max = 100;
	public bool removeOnDeath = true;
    public bool IsAlive()
    {
        return actual > 0;
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
		if(removeOnDeath)
			Destroy(gameObject);
	}

}