﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAmmo : MonoBehaviour {


	public float lenghtPerAmmo = 70;
	Weapon playerAmmo;
	Image image;

	// Use this for initialization
	void Start()
	{
		image = GetComponent<Image>();
		playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
	}

	// Update is called once per frame
	void Update()
	{
		image.fillAmount = playerAmmo.ammo / playerAmmo.maximumAmmo;
		image.transform.localScale = new Vector2(1 + playerAmmo.maximumAmmo / lenghtPerAmmo, 1);
	}
}
