using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCollision : MonoBehaviour {

	public Vector2 force;

	private void OnTriggerStay2D(Collider2D collision)
	{
		Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
		if(rb)
			rb.AddForce(new Vector2(transform.up.x, transform.up.y) * force.y + 
				new Vector2(transform.right.x, transform.right.y) * force.x
			);
	}
}
