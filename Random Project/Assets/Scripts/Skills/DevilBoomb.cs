using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBoomb : MonoBehaviour {

    public GameObject explosionDeath;
    public GameObject explosionCollsion;
    public float spawnRadius;

    public float deathExplosionRadius;
    public float deathExplosionForce;

    public int maxExplosionN;


    void OnDeath(HealthController.DamageData data)
    {
        if(explosionDeath)
            Instantiate(explosionDeath, transform.position, transform.rotation);
        
        var list = Physics2D.OverlapCircleAll(transform.position, deathExplosionRadius);
        foreach (var it in list)
        {
            Rigidbody2D body = it.gameObject.GetComponent<Rigidbody2D>();
            if (body)
            {
                Vector2 direction = (Vector2)transform.position - body.position;
                body.AddForce(-direction.normalized * deathExplosionForce);
            }
        } 
    }
    void OnReceiveDamage(HealthController.DamageData data) { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(maxExplosionN < 1)
            return;

        --maxExplosionN;
        if(explosionCollsion)
            Instantiate(explosionCollsion, (Vector2)transform.position + Random.insideUnitCircle*spawnRadius, transform.rotation);
    }
}
