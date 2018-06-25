using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnitMind : MonoBehaviour
{

	public float utilityThreshold = 0.0f;

	void Start()
	{
		conditions = GetComponents<AiConditionBase>();

		conditionChance = new RandomChance();
		conditionChance.chances = new float[conditions.Length];
		
		myFraction = GetComponentInParent<AiFraction>();
		myPerception = GetComponentInParent<AiPerception>();
	}

	void Update()
	{
		if (!currentBehaviour || currentBehaviour.PerformAction())
		{
			// choose new action
			if(currentBehaviour)
				currentBehaviour.ExitAction();

			currentBehaviour = selectNewBehaviour();

			if (currentBehaviour )
				currentBehaviour.EnterAction();
			
		}
	}



#region behaviours
	[System.NonSerialized]
	public AiConditionBase[] conditions;
	AiBehaviourBase currentBehaviour;
	RandomChance conditionChance;

	AiBehaviourBase selectNewBehaviour()
	{
		if (currentBehaviour && currentBehaviour.nextBehaviour )
			return currentBehaviour.nextBehaviour;

		for (int i = 0; i < conditions.Length; ++i)
		{
			float utility = conditions[i].GetUtility();
			conditionChance.chances[i] = utility >= utilityThreshold ? utility : 0;
			conditionChance.chances[i] = conditions[i].enabled && conditions[i].behaviour.CanEnter() ? conditionChance.chances[i] : 0;
		}
		var v = conditions[conditionChance.GetRandedId()];
		return v.behaviour;
	}
#endregion behaviours

#region Perception
	[System.NonSerialized]
	public AiFraction myFraction;
	[System.NonSerialized]
	public AiPerception myPerception;
#endregion Perception
}
