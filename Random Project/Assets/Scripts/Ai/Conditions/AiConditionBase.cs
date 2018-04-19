using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Condition holds data about how probably is to perform an specific behaviour
 */
[RequireComponent(typeof(AiUnitMind))]
public class AiConditionBase : MonoBehaviour {

	[System.NonSerialized]
	public AiUnitMind myMind;

    // behaviour to be performed if condition is choosen
	public AiBehaviourBase behaviour;
    // base utility value
	public float baseUtility = 1.0f;
    // the function should compute utility of the behaviour
	public virtual float GetUtility() { return baseUtility; }

	// Use this for initialization
	void Start () {
		myMind = GetComponent<AiUnitMind>();
	}
}
