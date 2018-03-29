using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightAllign : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float allignSpeed;
	Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = transform;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Vector3 pos = collision.transform.position;
		pos.z = pos.z + (transform.position.z - pos.z) * allignSpeed;
		collision.transform.position = pos;
	}
}
