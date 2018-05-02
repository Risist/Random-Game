using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	public Timer animationCd = new Timer(0);


	public void CastAnimation()
	{
		animator.SetTrigger(animHash);
		animationCd.restart();
	}
	public bool CanCastAnimation() { return animationCd.isReady(); }

	public Animator animator;
	public string animStartCode = "isCasting";
	int animHash;

	private void Start()
	{
		animHash = Animator.StringToHash(animStartCode);
		if (!animator)
			animator = GetComponent<Animator>();
	}
}
