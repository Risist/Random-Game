using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMeditation : MonoBehaviour {

	public HealthController hp;
	public float gain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hp.DealDamage(gain*Time.deltaTime);	
	}
}
