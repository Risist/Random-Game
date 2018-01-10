using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkillSlash: MonoBehaviour {

	public Weapon weapon;

	public float ammoCost;
	public string buttonCode = "Fire1";
	public string triggerEvent = "slash";
	public Timer timer = new Timer(0.5f);

	public AnimationManager animManager;
	public PlayerWSADMovement movement;
	bool ahouldShoot = false;

	// Use this for initialization
	void Start () {
		if (!weapon)
			weapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton(buttonCode))
		{
			if (movement)
			{
				movement.applyRotationToMouse();
			}
			if (timer.isReady() && weapon.UseAmmo(ammoCost))
			{
				if (animManager)
					animManager.animator.SetTrigger(triggerEvent);
				timer.restart();
				ahouldShoot = true;
			}
		}
	}
}
