using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UiHealth : MonoBehaviour {

	HealthController playerHp;
	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
		image.fillAmount = playerHp.actual / playerHp.max;
	}
}
