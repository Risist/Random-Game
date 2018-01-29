using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPickup : MonoBehaviour {

	public float xp;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			var manager = collision.GetComponent<LvlManager>();
			if (manager)
			{
				manager.GainXp(xp);
				Destroy(gameObject);
			}
		}
	}
}
