using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnCollision : MonoBehaviour
{
	public GameObject prefab;
	public string ignoreTag = "noTag";
	public string attachType;
	public bool onEnter = true;
	public bool onExit = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!onEnter)
			return;
		var hp = collision.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			Attach(collision.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!onExit)
			return;
		var hp = collision.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			Attach(collision.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!onEnter)
			return;
		var hp = collision.gameObject.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			Attach(collision.gameObject);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (!onExit)
			return;
		var hp = collision.gameObject.GetComponent<HealthController>();
		if (hp && hp.tag != ignoreTag)
		{
			Attach(collision.gameObject);
		}
	}

	void Attach(GameObject obj)
	{
		var attaches = obj.GetComponentsInChildren<AttachBase>();
		foreach (var it in attaches)
			if(it.type == attachType)
			{
				it.stayTime.restart();
				return;
			}
		
		var v = Instantiate(prefab, obj.transform.position, obj.transform.rotation);
		v.transform.parent = obj.transform;
	}
}
