﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponBase : MonoBehaviour
{

    public NewtonianResource increaseCost;
    public float increaseCostForce;
	EnergyController resource;
	public float cost;
    public float minimalEnergy;

	//[System.NonSerialized]
	public string buttonCode;
	public Timer cd = new Timer(0.5f);
	[System.NonSerialized]
	public new AudioSource audio;
	public PlayerMovement movement;
    public WeaponCommonCd[] commonCd;

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
    protected bool isButtonPressed()
    {
        return Input.GetAxis(buttonCode) > 0.1 && !EventSystem.current.IsPointerOverGameObject();
    }
	protected bool CastSkill()
	{
        bool b = true;
        foreach (var it in commonCd)
            b = b && it.timer.isReady();

        if (b && Input.GetAxis(buttonCode) > 0.1 && !EventSystem.current.IsPointerOverGameObject() && cd.isReady() && resource.HasEnough(cost + increaseCost.GetVelocity() + minimalEnergy)
            )
        {
            resource.Spend(cost + increaseCost.GetVelocity());

            foreach (var it in commonCd)
                it.timer.restart();

            increaseCost.AddForce(increaseCostForce);
            cd.restart();
            return true;
        }
        return false;
	}
  
}
