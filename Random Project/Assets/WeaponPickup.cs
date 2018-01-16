using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			var manager = collision.GetComponent<SkillManager>();
			if(manager)
			{
				if (manager.unlockSkill(Random.Range(0, manager.possibleSkills.Length)))
					Destroy(gameObject);
			}
		}
	}
}
