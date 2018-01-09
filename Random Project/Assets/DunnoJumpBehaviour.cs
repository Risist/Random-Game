using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunnoJumpBehaviour : StateMachineBehaviour {

	public float movementSpeed;

	public float minRadiusFromAim;
	public float maxRadiusFromAim;

	public float addictionalAngle = 180.0f;

	Vector2 directionOfMove;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		// find move aim 
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player)
		{
			Vector2 aim = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * Random.Range(minRadiusFromAim, maxRadiusFromAim);

			directionOfMove = (aim - (Vector2)animator.gameObject.transform.position).normalized;
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var rb = animator.transform.parent.GetComponent<Rigidbody2D>();
		rb.AddForce(directionOfMove * movementSpeed);
		rb.rotation = Vector2.Angle(Vector2.up, directionOfMove) * (directionOfMove.x > 0 ? -1 : 1) + addictionalAngle;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
