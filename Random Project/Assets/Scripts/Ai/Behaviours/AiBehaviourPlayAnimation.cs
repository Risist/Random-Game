using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviourPlayAnimation : AiBehaviourBase {


	protected bool b;
	protected new void Start()
	{
		base.Start();
		animationCodeHash = Animator.StringToHash(animationCode);
		animator = GetComponentInParent<Animator>();
	}


	public override bool PerformAction()
	{
		if(b)
		{
			PlayAnimationTrigger();
			b = false;
		}
		return true;
	}
	public override void EnterAction()
	{
		base.EnterAction();
		b = true;
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
