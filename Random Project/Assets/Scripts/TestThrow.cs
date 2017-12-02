using UnityEngine;
using System.Collections;

/// #Placeholder

public class TestThrow : SpawnMethodBase {

    public GameObject prefab;
    public string buttonCode = "Fire1";
    public Timer timer = new Timer(0.5f);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(buttonCode) && timer.isReadyRestart() )
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
	}
}
