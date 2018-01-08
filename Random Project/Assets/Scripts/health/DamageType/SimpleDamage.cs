using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[System.Serializable]
public class SimpleDamage : IDamageType
{
    public SimpleDamage(float _damage = 0)
    {
        damage = _damage;
    }
    public float damage;

    public void ChangeHealth(HealthController hpC, GameObject causer)
    {
        hpC.actual += damage;
        Mathf.Clamp(hpC.actual, 0, hpC.max);
    }
	public float toFloat() { return damage;  } 
}
