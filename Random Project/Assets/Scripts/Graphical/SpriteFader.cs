using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  changes alpha canal of a sprite
/// </summary>
public class SpriteFader : MonoBehaviour {

	/// change rate swaps its sign after some delay
	public bool reverse = false;
	public Timer reverseTimer;
	public float changeRate;
	public float min = 0;
	public float max = 1;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		reverseTimer.restart();
	}
	
	// Update is called once per frame
	void Update () {
		if (reverse && reverseTimer.isReadyRestart())
			changeRate *= -1;
		float a = sprite.color.a + changeRate * Time.deltaTime;

		sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Clamp(a, min,max) );
	}
}
