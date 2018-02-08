using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBase : MonoBehaviour {

	public string type;
	public Timer stayTime;

	// Use this for initialization
	protected void Start () {
		stayTime.restart();
	}

	// Update is called once per frame
	protected void Update ()
	{
		if(stayTime.isReady())
		{
			Destroy(gameObject);
		}
	}
}
