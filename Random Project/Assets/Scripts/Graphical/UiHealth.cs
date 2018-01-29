using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UiHealth : MonoBehaviour {

	public float lenghtPerHp = 70;
	public bool updateProgress = true;
	HealthController playerHp;
	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(updateProgress)
			image.fillAmount = playerHp.actual / playerHp.max;
		image.transform.localScale = new Vector2(1 + playerHp.max / lenghtPerHp, 1);
	}
}
