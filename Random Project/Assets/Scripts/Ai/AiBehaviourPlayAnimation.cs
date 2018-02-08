using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviourPlayAnimation : ArmyBehaviourBase {

	protected new void Start()
	{
		base.Start();
		animationCodeHash = Animator.StringToHash(animationCode);
		if (!animator)
			animator = GetComponent<Animator>();
	}

	public override void EnterAction()
	{
		PlayAnimationTrigger();
		base.EnterAction();
	}

	#region animation
	public string animationCode;
	public Animator animator;
	int animationCodeHash;
	protected void PlayAnimationTrigger()
	{
		animator.SetTrigger(animationCodeHash);
	}
	#endregion animation
}
