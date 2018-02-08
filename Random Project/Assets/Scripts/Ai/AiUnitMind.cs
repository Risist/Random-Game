using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyUnitMind : MonoBehaviour
{

	void Start()
	{
		behaviourChance = new RandomChance();
		behaviourChance.chances = new float[behaviours.Length];

		if (!myFraction)
			myFraction = GetComponent<AiFraction>();
		if (!perceptionTransform)
			perceptionTransform = transform;

		currentBehaviour = selectNewBehaviour("freeWill");
	}

	void Update()
	{
		if (currentBehaviour.PerformAction())
		{
			// choose new action
			currentBehaviour.ExitAction();
			currentBehaviour = selectNewBehaviour("freeWill");
		}

		if (perceptionPeriod.isReadyRestart())
			enemyAim = PerformPerceptionCheck();

	}
	void FixedUpdate()
	{
		currentBehaviour.PerformActionFixed();	
	}



	#region behaviours
	public ArmyBehaviourBase[] behaviours;
	public ArmyBehaviourBase currentBehaviour;
	RandomChance behaviourChance;

	ArmyBehaviourBase selectNewBehaviour(string orderCode)
	{
		for (int i = 0; i < behaviours.Length; ++i)
			behaviourChance.chances[i] = behaviours[i].GetUtility(orderCode);
		var v = behaviours[behaviourChance.GetRandedId()];
		v.EnterAction();
		return v;
	}
	#endregion behaviours

	#region perception
	/// fraction data. Perception will scan for any object in the area with ArmyFraction component that differs in fraction
	public AiFraction myFraction;

	/// how often to perform perception checks
	public Timer perceptionPeriod = new Timer(0.3f);
	
	/// Circle-type collider data of perception area
	/// transform by default is equal to owner of mind
	public float perceptionRadius = 10.0f;
	public Transform perceptionTransform;

	public GameObject PerformPerceptionCheck()
	{
		var colliders = Physics2D.OverlapCircleAll(perceptionTransform.position,
			perceptionRadius * Mathf.Max(perceptionTransform.localScale.x, perceptionTransform.localScale.y)
			);

		foreach( var it in colliders)
		{
			var fraction = it.GetComponent<AiFraction>();
			if (fraction && !fraction.fractionName.Equals(myFraction.fractionName))
				return it.gameObject;
		}
		return null;
	}

	/// first found non-ally object in perception area
	GameObject enemyAim;
	public GameObject GetEnemyAim() { return enemyAim; }

	#endregion perception
}
