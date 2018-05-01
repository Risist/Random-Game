﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponBase : MonoBehaviour
{
	[System.NonSerialized]
	public bool isUnlocked = false;

#region Requirements
	public ProgressionManager.Fate[] requiredFates;
	public WeaponBase[] requiredSkills;

	public bool MeetsRequirements()
	{
		var manager = GetComponentInParent<ProgressionManager>();
		foreach (var itRequired in requiredFates)
		{
			bool found = false;
			foreach (var itOwned in manager.chosenFates)
				if (itOwned.name == itRequired.name && itOwned.lvl >= itRequired.lvl)
				{
					found = true;
					break;
				}

			if (!found)
				return false;
		}

		foreach (var itRequired in requiredSkills)
			if (!itRequired.isUnlocked)
				return false;
		
		return true;
	}
    #endregion Requirements

    public NewtonianResource increaseCost;
    public float increaseCostForce;
	EnergyController resource;
	public float cost;

	[System.NonSerialized]
	public string buttonCode;
	public Timer cd = new Timer(0.5f);
	[System.NonSerialized]
	public new AudioSource audio;
	public PlayerMovement movement;

#region Ui
    public Sprite skillIcon;
	public string displayName;
	public string description;
#endregion Ui


    protected void Start()
	{
		resource = GetComponentInParent<EnergyController>();
		audio = GetComponent<AudioSource>();
	}
    protected void FixedUpdate()
    {
        increaseCost.FixedUpdate();
    }

    protected void PlaySound()
	{
		if (audio)
			audio.Play();
	}
	protected bool CastSkill()
	{
        if (Input.GetButton(buttonCode) && !EventSystem.current.IsPointerOverGameObject() && cd.isReady() && resource.Spend(cost + increaseCost.GetVelocity()))
        {
            increaseCost.AddForce(increaseCostForce);
            cd.restart();
            return true;
        }
        return false;
	}
  
}
