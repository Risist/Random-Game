using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventPhysicsDestruction : MonoBehaviour {

	// explosion data
	public float forceBase;
	public float forceScale;
	public float forceMax = 4500;
	public float explosionRadius;
	// remove & fadeout data
	public float removeDelay;
	// physics data
	public float mass;
	public float linearDamping;
	public float angularDamping;

	void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		body.AddForce(dir.normalized * explosionForce * wearoff);
	}

	void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		Vector3 baseForce = dir.normalized * explosionForce * wearoff;
		body.AddForce(baseForce);

		float upliftWearoff = 1 - upliftModifier / explosionRadius;
		Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
		body.AddForce(upliftForce);
	}

	void OnDeath(HealthController.DamageData data)
	{
		Vector2 explosionPosition = transform.position;
		if (data.causer)
			explosionPosition = data.causer.transform.position;

		var sprites = GetComponentsInChildren<SpriteRenderer>();
		foreach(var it in sprites)
		{
			it.transform.parent = null;
			var rb = it.GetComponent<Rigidbody2D>();

			if (!rb)
				rb = it.gameObject.AddComponent<Rigidbody2D>();

			rb.mass = mass;
			rb.drag = linearDamping;
			rb.angularDrag = angularDamping;
			AddExplosionForce(rb, Mathf.Clamp( forceBase - forceScale * data.damage.toFloat(),-forceMax, forceMax) , explosionPosition, explosionRadius);

			var remove = it.gameObject.AddComponent<RemoveAfterDelay>();
			remove.timer = new Timer(removeDelay);

			var fader = it.gameObject.AddComponent<SpriteFader>();
			fader.changeRate = -it.color.a / removeDelay;
			fader.reverseTimer = new Timer();
			fader.reverse = false;
		}
		Destroy(this);
	}
}
