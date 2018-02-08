using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
	public string type;
	public float maxBonus;
	public float actualBonus;
	public float bonusRegen;

	public bool antidotum = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var res = collision.GetComponents<ResourceController>();
			foreach (var r in res)
				if(r.type == type)
			{
				r.max += maxBonus;
				r.regeneration += bonusRegen;
				r.Gain(actualBonus);

				if (antidotum && r.regeneration < 0)
					r.regeneration = 0;

				Destroy(gameObject);
				return;
			}
		}

	}

}
