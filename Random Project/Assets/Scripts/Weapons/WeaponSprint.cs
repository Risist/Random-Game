using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprint : WeaponBase {

	public float sprintSpeed;
	float movementSpeed;
	bool readyToSprint = true;
	public Timer sprintTime;

	// Use this for initialization
	void Start () {
		if (!weapon)
			weapon = GetComponent<Weapon>();
		movementSpeed = movement.movementSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (!movement)
			return;

		if (Input.GetButton(buttonCode) && timer.isReady() && weapon.UseAmmo(ammoCost))
		{
			sprintTime.restart();
			timer.restart();
		}

		if(!sprintTime.isReady())
		{
			movement.movementSpeed = sprintSpeed;
		}
		else
			movement.movementSpeed = movementSpeed;
	}
}
