using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : MonoBehaviour
{
	public Weapon weapon;

	public float ammoCost;
	public GameObject prefab;
	public string buttonCode = "Fire1";
	public Timer timer = new Timer(0.5f);

	// Use this for initialization
	void Start()
	{
		if (!weapon)
			weapon = GetComponent<Weapon>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton(buttonCode) && timer.isReady() && weapon.UseAmmo(ammoCost) )
		{
			Instantiate(prefab, transform.position, transform.rotation);
			timer.restart();
		}
	}
}
