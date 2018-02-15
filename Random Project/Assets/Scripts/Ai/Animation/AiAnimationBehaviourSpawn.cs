using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimationBehaviourSpawn : StateMachineBehaviour
{
	public GameObject bulletPrefab;
	public Vector2 bulletSpawnPositionOffset;
	public float bulletSpawnRotationOffset;

	public Timer cdSpawn;
	bool thrown = false;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		thrown = false;
		cdSpawn.restart();
		animator.GetComponentInParent<AiMovement>().SetRotationPoint( new Vector2( animator.GetFloat("aimX"), animator.GetFloat("aimY") ) );
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (thrown == false && cdSpawn.isReadyRestart())
		{
			Instantiate(bulletPrefab, animator.transform.parent.position
				+ animator.transform.up * bulletSpawnPositionOffset.y
				+ animator.transform.right * bulletSpawnPositionOffset.x,
				Quaternion.Euler(0, 0, animator.transform.parent.rotation.eulerAngles.z + bulletSpawnRotationOffset)
			);
			thrown = true;
		}
	}

}
