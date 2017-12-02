using UnityEngine;
using System.Collections;
using System;

public class DeathEventDestroy : MonoBehaviour
{
    public void OnDeath(HealthController.DamageData data)
    {
        Destroy(gameObject);    
    }
}
