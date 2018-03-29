using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHeightMarker : MonoBehaviour {


	public float heightOffset;
	public float turnOffDiff;

	void Start () {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteHeightManager>()
			.AddHeightObject(gameObject, heightOffset, turnOffDiff);
		Destroy(this);
	}
}
