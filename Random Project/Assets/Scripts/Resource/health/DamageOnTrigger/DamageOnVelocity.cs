using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnVelocity : MonoBehaviour {
    
    public float damageScale;
    /// minimal damage required to deal damage
    /// if value is lover damage is ignored
    public float damageMin;
    public float damageMax;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        if (healthController)
        {
            Vector2 toAim = (rb.position - (Vector2)collision.gameObject.transform.position).normalized;
            float damage = Vector2.Dot(rb.velocity.normalized, toAim) * damageScale*rb.velocity.magnitude;
            if(damage > damageMin)
                healthController.DealDamage(-Mathf.Clamp(damage, 0, damageMax + damageMin) + damageMin);    
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        if (healthController)
        {
            Vector2 toAim = (rb.position - (Vector2)collision.gameObject.transform.position).normalized;
            float damage = Vector2.Dot(rb.velocity.normalized, toAim) * damageScale * rb.velocity.magnitude;
            if (damage > damageMin)
                healthController.DealDamage(-Mathf.Clamp(damage, 0, damageMax + damageMin) + damageMin);
        }
    }
}
