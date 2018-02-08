using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ResourceUiDisplayer : MonoBehaviour
{

	//public float lenghtPerHp = 70;
	public bool updateProgress = true;
	public ResourceController resource;
	Image image;

	// Use this for initialization
	void Start()
	{
		image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update()
	{
		if (updateProgress)
			image.fillAmount = resource.actual / resource.max;
		//image.transform.localScale = new Vector2(1 + playerHp.max / lenghtPerHp, 1);
	}
}
