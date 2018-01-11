using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  changes alpha canal of a sprite
/// </summary>
public class ImageFader : MonoBehaviour
{

	/// change rate swaps its sign after some delay
	public bool reverse = false;
	public Timer reverseTimer;
	public float changeRate;
	public float min = 0;
	public float max = 1;

	Image sprite;
	Text txt;

	// Use this for initialization
	void Start()
	{

		sprite = GetComponent<Image>();
		txt = GetComponent<Text>();
		reverseTimer.restart();
	}

	// Update is called once per frame
	void Update()
	{
		if (reverse && reverseTimer.isReadyRestart())
			changeRate *= -1;
		if (sprite)
		{
			float a = sprite.color.a + changeRate * Time.deltaTime;

			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Clamp(a, min, max));
		}
		if (txt)
		{
			float a = txt.color.a + changeRate * Time.deltaTime;

			txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.Clamp(a, min, max));
		}
	}
}
