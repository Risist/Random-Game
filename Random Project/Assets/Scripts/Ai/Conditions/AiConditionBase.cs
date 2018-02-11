using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiUnitMind))]
public class AiConditionBase : MonoBehaviour {

	[System.NonSerialized]
	public AiUnitMind myMind;

	public AiBehaviourBase behaviour;
	public float baseUtility = 1.0f;
	public virtual float GetUtility() { return baseUtility; }

	// Use this for initialization
	void Start () {
		myMind = GetComponent<AiUnitMind>();
	}
}
