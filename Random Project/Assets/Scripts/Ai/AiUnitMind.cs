using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Main decision script
 * 
 * Decides with random probability which behaviour to run at the moment
 */
public class AiUnitMind : MonoBehaviour
{
    // minimal utility value the behaviour has to have in order to be considered to be choosen
	public float utilityThreshold = 0.0f;

	void Start()
	{
		conditions = GetComponents<AiConditionBase>();

		conditionChance = new RandomChance();
		conditionChance.chances = new float[conditions.Length];
		
		myFraction = GetComponentInParent<AiFraction>();
		myPerception = GetComponentInParent<AiPerception>();
        myMovement = GetComponentInParent<AiMovement>();
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
    // list of conditions // posible actions with their utility value
	[System.NonSerialized]
	public AiConditionBase[] conditions;

    // currently processed behaviour
    // current system requires multiplay AiUnitMinds to run several behaviours at the same time
    // TODO way to implement parallel behaviour actions
	AiBehaviourBase currentBehaviour;
	RandomChance conditionChance;

    // selects and returns a new behaviour to be processed
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
    // fraction the agent belongs to
    // defines relations/attitude between agents
	[System.NonSerialized]
	public AiFraction myFraction;
    // Perception scans environment and stores information about found perceiveable objects
	[System.NonSerialized]
	public AiPerception myPerception;
#endregion Perception

	// reference to my current army
    // WIP
	public AiArmy myArmy;

    [System.NonSerialized]
    public AiMovement myMovement;
}
