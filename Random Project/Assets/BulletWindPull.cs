using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWindPull : MonoBehaviour {

    public Timer tSwapDirection;
    bool swaped = false;

    public float movementSpeed;
    public float pullForceBase;
    public float pullForceOverTime;

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        tSwapDirection.restart();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!swaped && tSwapDirection.isReady())
        {
            body.rotation += 180.0f;
            swaped = true;
        }
	}

    void FixedUpdate()
    {
        if(swaped)
            pullForceBase += pullForceOverTime * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger || !swaped)
            return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb)
            rb.AddForce(new Vector2(transform.up.x, transform.up.y) * pullForceBase
            );
    }
}
