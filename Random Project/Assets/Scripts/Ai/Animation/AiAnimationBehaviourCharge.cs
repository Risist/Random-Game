using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimationBehaviourCharge : StateMachineBehaviour
{
	public string aimCode = "aim";
	public string speedCode = "speed";
	float movementSpeed;

	AiMovement movement;
	Vector2 directionOfMove;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Vector2 aim = new Vector2(animator.GetFloat(aimCode + "X"), animator.GetFloat(aimCode + "Y") );
		movementSpeed = animator.GetFloat(speedCode);

		movement = animator.GetComponentInParent<AiMovement>();
		movement.SetRotationPoint(aim);
		directionOfMove = (aim - (Vector2)movement.transform.position).normalized * movementSpeed;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movement.applyInfluencePosition(directionOfMove);
	}
}
