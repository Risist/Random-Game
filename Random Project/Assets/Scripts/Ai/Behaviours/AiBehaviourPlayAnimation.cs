using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourPlayAnimation : AiBehaviourBase {

	protected new void Start()
	{
		base.Start();
		animationCodeHash = Animator.StringToHash(animationCode);
		animator = GetComponentInParent<Animator>();
	}

	
	public override void EnterAction()
	{
		base.EnterAction();
		PlayAnimationTrigger();
	}

#region animation
	public string animationCode;
	[System.NonSerialized]
	public Animator animator;
	int animationCodeHash;
	protected void PlayAnimationTrigger()
	{
		animator.SetTrigger(animationCodeHash);
	}
#endregion animation
}
