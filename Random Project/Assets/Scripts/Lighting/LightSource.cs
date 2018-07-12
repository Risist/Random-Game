using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour {

    public float fullLightDistance;
    public float intensitivityFall;
    public float maxIntensitivityRatio;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
        LightManager.instance.checkLightSource(gameObject, fullLightDistance, 
            intensitivityFall, maxIntensitivityRatio);
    }
}