using UnityEngine;
using System.Collections;

public abstract class DamageOnTrigger : MonoBehaviour {

    protected IDamageType _damageEnter;
    protected IDamageType _damageStay;
    protected IDamageType _damageExit;

    void OnTriggerEnter2D(Collider2D other)
    {
        HealthController healthController= other.gameObject.GetComponent<HealthController>();
        if (other.isTrigger == false && healthController != null && _damageEnter != null)
        {
            healthController.DealDamage(_damageEnter, gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (other.isTrigger == false && healthController != null && _damageExit != null)
        {
            healthController.DealDamage(_damageStay, gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (other.isTrigger == false && healthController != null && _damageExit != null)
        {
            healthController.DealDamage(_damageExit, gameObject);
        }
    }

}
