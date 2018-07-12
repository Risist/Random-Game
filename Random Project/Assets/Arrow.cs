using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public Rigidbody2D body;
    public AiFraction fraction;

    public float damage;
    public float initialMovementSpeed;
    public float movementSpeed;
    public float pushForce;

    private void Start()
    {
        if (!body)
            body = GetComponent<Rigidbody2D>();

        body.AddForce(-transform.up*initialMovementSpeed);
    }

    private void FixedUpdate()
    {
        body.AddForce( body.velocity.normalized * movementSpeed * Time.fixedDeltaTime);
        body.rotation = Vector2.SignedAngle(-Vector2.up, body.velocity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AiPerceiveUnit unit = collision.gameObject.GetComponent<AiPerceiveUnit>();

        if (fraction && unit && unit.fraction && fraction.GetAttitude(unit.fraction.fractionName) == AiFraction.Attitude.friendly)
            return;

        HealthController health = collision.gameObject.GetComponent<HealthController>();
        if(health)
        {
            Destroy(gameObject);
            health.DealDamage(damage * body.velocity.magnitude);

            Rigidbody2D _body = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_body)
            {
                _body.AddForce(-transform.up * pushForce * Time.fixedDeltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AiPerceiveUnit unit = collision.gameObject.GetComponent<AiPerceiveUnit>();
        if (fraction && unit && unit.fraction && fraction.GetAttitude(unit.fraction.fractionName) == AiFraction.Attitude.friendly)
            return;

        HealthController health = collision.gameObject.GetComponent<HealthController>();
        if (health)
        {
            Destroy(gameObject);
            health.DealDamage(damage * body.velocity.magnitude);

            Rigidbody2D _body = collision.gameObject.GetComponent<Rigidbody2D>();
            if(_body)
            {
                _body.AddForce(-transform.up * pushForce * Time.fixedDeltaTime);
            }
        }
    }
}
